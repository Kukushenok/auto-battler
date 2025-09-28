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

        public async Task Play()
        {
            IWeapon weaponOverride = null;
            List<ISkillDescriptor> chosenSkills = new List<ISkillDescriptor>();
            float playerHealth = 0;
            for (int currRounds = 1; currRounds <= m_Settings.WinRoundsCount; currRounds++)
            {
                await m_Settings.Controller.ShowStage(currRounds);

                var playerBuilder = m_Settings.EntityRepository.GetPlayer();
                if (weaponOverride != null) playerBuilder = playerBuilder.OverrideWeapon(weaponOverride);

                // CHOOSE A SKILL
                var skills = m_Settings.SkillRepository.GetSkills();
                var newSkill = await m_Settings.Controller.ChooseGameSkill(skills);
                m_Settings.SkillRepository.Choose(newSkill);
                chosenSkills.Add(newSkill);
                playerHealth += newSkill.HealthBonus;
                playerBuilder = playerBuilder.OverrideHealth(new Health(playerHealth));

                // SETUP
                foreach (var S in chosenSkills)
                {
                    playerBuilder = playerBuilder.AddSkill(S.CreateSkill());
                }
                var fights = m_Settings.EntityRepository.GetFights().ToList();
                var chosenFight = fights[m_Settings.Random.GetRange(0, fights.Count)];

                // FIGHT
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
                weaponOverride = await m_Settings.Controller.ChooseWeapon(player.Weapon, chosenFight.GetReward());
            }
            await m_Settings.Controller.ShowGameOver(true);
        }
    }
}
