using AutoBattler.External;
using AutoBattler.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBattler
{
    public class AutoBattler : IPlayable
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
        private async Task<ISkillTree> ChooseTree(bool disableWeapons = false)
        {
            ISkillTree resTree = null;
            var skillTrees = m_Settings.SkillRepository.GetSkillTrees().Where(x => !x.IsExausted).ToList();
            if (disableWeapons)
            {
                skillTrees = skillTrees.Select(x => (ISkillTree)new SkillTreeDisabledWeapon(x)).ToList();
            }
            if (skillTrees.Count > 0)
            {
                resTree = await m_Settings.Controller.ChooseSkillTree(skillTrees);
            }
            return resTree;
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
                var tree = await ChooseTree(currRounds > 1);
                if (tree != null)
                {
                    var weapon = tree.GetWeapon();
                    if (weapon != null) weaponOverride = weapon;
                    chosenSkills.Add(tree.GetCurrentSkill());
                    aquiredLevel = true;
                    playerHealth += tree.HealthBonus;
                    m_Settings.SkillRepository.Choose(tree);
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
                if (player.Health.IsDead)
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
