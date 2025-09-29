using AutoBattler.External;
using AutoBattler.Utils;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace AutoBattler
{
    public class AutoBattler: IPlayable
    {
        public struct Settings
        {
            public int WinRoundsCount;
            public IEntityRepository EntityRepository;
            public ISkillRepository SkillRepository;
            public IRandom Random;
            public IGameController Controller;
        }
        private readonly Settings m_Settings;
        public AutoBattler(Settings settings)
        {
            m_Settings = settings;
        }
        private async Task<(ISkillDescriptor, IWeapon)> ChooseSkill()
        {
            IWeapon resWeapon = null;
            ISkillDescriptor chosenSkill = null;
            var skills = m_Settings.SkillRepository.GetSkills();
            List<ISkillDescriptor> descriptors = new List<ISkillDescriptor>();
            foreach(var x in skills)
            {
                if (!x.IsExausted) descriptors.Add(x.GetCurrentSkill());
            }
            if (descriptors.Count > 0)
            {
                chosenSkill = await m_Settings.Controller.ChooseGameSkill(descriptors);
                foreach (var x in skills)
                {
                    if (!x.IsExausted)
                    {
                        if(x.GetCurrentSkill() == chosenSkill)
                        {
                            resWeapon = x.GetStartingWeapon();
                            m_Settings.SkillRepository.Choose(x);
                            break;
                        }
                    }
                }
            }
            return (chosenSkill, resWeapon);
        }
        private IEntityStats ChooseRandomStats() => new EntityStats(
                m_Settings.Random.GetRange(1, 4),
                m_Settings.Random.GetRange(1, 4),
                m_Settings.Random.GetRange(1, 4)
            );
        public async Task Play()
        {
            IWeapon weaponOverride = null;
            List<ISkillDescriptor> chosenSkills = new List<ISkillDescriptor>();
            float playerHealth = 0;
            var defaultStats = ChooseRandomStats();
            await m_Settings.Controller.ShowStartingStats(defaultStats);
            for (int currRounds = 1; currRounds <= m_Settings.WinRoundsCount; currRounds++)
            {
                await m_Settings.Controller.ShowStage(currRounds);

                // CHOOSE A SKILL
                bool aquiredLevel = false;
                (var newSkill, var skillTreeWeapon) = await ChooseSkill();
                if (newSkill != null)
                {
                    weaponOverride ??= skillTreeWeapon;
                    chosenSkills.Add(newSkill);
                    aquiredLevel = true;
                    playerHealth += newSkill.HealthBonus;
                }

                // SETUP
                var playerBuilder = m_Settings.EntityRepository.GetPlayer();
                if (weaponOverride != null) playerBuilder = playerBuilder.OverrideWeapon(weaponOverride);
                IEntityStats aquireStats = defaultStats;
                foreach (var S in chosenSkills)
                {
                    var ingameSkill = S.CreateSkill();
                    aquireStats = ingameSkill.ModifySelfStats(aquireStats);
                    playerBuilder = playerBuilder.AddSkill(ingameSkill);
                }
                if (aquiredLevel)
                {
                    playerHealth += aquireStats.Endurance;
                }
                playerBuilder = playerBuilder.OverrideHealth(new Health(playerHealth)).OverrideStats(defaultStats);


                // FIGHT
                var fights = m_Settings.EntityRepository.GetFights().ToList();
                var chosenFight = fights[m_Settings.Random.GetRange(0, fights.Count)];
                var player = playerBuilder.Build();
                var enemy = chosenFight.GetOpposingEntity().Build();
                var section = new BattleArenaSection(m_Settings.Random, m_Settings.Controller.Battle(), player, enemy);
                await section.Play();
                if(player.Health.IsDead)
                {
                    await m_Settings.Controller.ShowGameOver(false);
                    return;
                }

                // CHOOSE WEAPON
                if (currRounds != m_Settings.WinRoundsCount)
                {
                    weaponOverride = await m_Settings.Controller.ChooseWeapon(player.Weapon, chosenFight.GetReward());
                }
            }
            await m_Settings.Controller.ShowGameOver(true);
        }
    }
}
