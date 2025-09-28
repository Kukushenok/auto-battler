using AutoBattler.External;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace AutoBattler
{
    public class SkillfulEntity : IBattleEntity
    {
        private string skinID;
        public IEntityStats Stats { get; private set; }

        public IHealth Health { get; private set; }

        public IWeapon Weapon { get; private set; }

        private List<IGameSkill> Skills;
        public SkillfulEntity(string SkinID, IHealth HP, IEntityStats stats, IEnumerable<IGameSkill> skills, IWeapon weapon = null)
        {
            skinID = SkinID;
            Health = HP;
            Skills = skills.ToList();
            foreach(var S in Skills)
            {
                stats = S.ModifySelfStats(stats);
            }
            Stats = stats;
        }
        public IAttackBuilder DoAttack(IAttackBuilder builder)
        {
            foreach(var S in Skills)
            {
                builder = S.ModifyEnemy(builder);
            }
            builder = builder.WithAttackerStats(Stats);
            if (Weapon != null)
            {
                builder = builder.WithAttack(Weapon.Source, Weapon.Damage + Stats.Strength);
            }
            else
            {
                builder = builder.WithAttack(AttackType.Ability, Stats.Strength);
            }
            foreach (var S in Skills)
            {
                builder = S.AttackEnemy(builder);
            }
            return builder;
        }

        public IAttackBuilder GetAttackBuilder()
        {
            IAttackBuilder atk = new BasicAttackBuilder(Stats);
            foreach(var S in Skills)
            {
                atk = S.ModifySelf(atk);
            }
            return atk;
        }

        public void Visualize(IBattleEntityPresenter presenter)
        {
            presenter.UseSkin(skinID);
            presenter.WithStats(Stats);
            if (Weapon != null) presenter.WithWeapon(Weapon);
            presenter.WithHealth(Health);
            Skills.ForEach(S => S.AddVisualEffects(presenter));
        }
    }
    public struct EntityStats : IEntityStats
    {
        public readonly int Strength { get; }

        public readonly int Dexterity { get; }

        public readonly int Endurance { get; }
        public EntityStats(int strength, int dexterity, int endurance)
        {
            Strength = strength;
            Dexterity = dexterity;
            Endurance = endurance;
        }
    }
    public class SkillfulEntityBuilder : IBattleEntityBuilder
    {
        private string m_SkinID;
        private List<IGameSkill> m_Skills = new List<IGameSkill>();
        private IHealth m_Health;
        private IEntityStats m_Stats;
        private IWeapon m_Weapon;
        public SkillfulEntityBuilder(string skinID)
        {
            m_SkinID = skinID;
        }

        public IBattleEntityBuilder AddSkill(IGameSkill skill)
        {
            m_Skills.Add(skill);
            return this;
        }

        public IBattleEntity Build()
        {
            return new SkillfulEntity(m_SkinID, m_Health, m_Stats, m_Skills, m_Weapon);
        }

        public IBattleEntityBuilder OverrideHealth(IHealth health)
        {
            m_Health = health;
            return this;
        }

        public IBattleEntityBuilder OverrideStats(IEntityStats stats)
        {
            m_Stats = stats;
            return this;
        }

        public IBattleEntityBuilder OverrideWeapon(IWeapon weapon)
        {
            m_Weapon = weapon;
            return this;
        }
    }
}
