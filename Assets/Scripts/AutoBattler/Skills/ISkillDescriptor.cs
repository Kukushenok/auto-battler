using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static UnityEditor.ObjectChangeEventStream;

namespace AutoBattler
{
    public interface IGameSkill
    {
        public IAttackBuilder ModifySelf(IAttackBuilder bldr) => bldr;
        public IAttackBuilder ModifyEnemy(IAttackBuilder bldr) => bldr;
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr) => bldr;
        public IEntityStats ModifySelfStats(IEntityStats stats) => stats;
        public void OnStartOpposing(IAutoBattlerEntity entity);
        public void OnMoveCompleted();
    }
    public interface ISkillDescriptor
    {
        public IGameSkill AddTo(IAutoBattlerEntity entity);
    }
    public class Health : IHealth
    {
        public float MaxHP { get; private set; }

        public bool IsDead { get => HP <= 0; }

        public float HP { get; private set; }

        public void DoDamage(float damage)
        {
            this.HP -= damage;
        }

        public void ResetHealth()
        {
            this.HP = this.MaxHP;
        }
        public Health(float HP)
        {
            MaxHP = HP;
            this.HP = HP;
        }
    }
    public class BasicCompositeAttack : IAttack
    {
        private List<IAttack> m_Attacks;
        private readonly float m_TotalDamage;
        public BasicCompositeAttack(IEnumerable<IAttack> attacks)
        {
            m_Attacks = attacks.ToList();
            m_TotalDamage = m_Attacks.Sum(x => x.TotalDamage);
            if (m_TotalDamage < 0) m_TotalDamage = 0;
        }
        float IAttack.TotalDamage => m_TotalDamage;

        public async Task Visualize(IAttackPresenter presenter)
        {
            foreach(var attack in m_Attacks)
            {
                await attack.Visualize(presenter);
            }
        }
    }
    public class BasicAttack: IAttack
    {
        private AttackSource m_Source;

        public float TotalDamage { get; private set; }
        public BasicAttack(AttackSource source, float totalDamage)
        {
            this.m_Source = source;
            TotalDamage = totalDamage;
        }

        public async Task Visualize(IAttackPresenter presenter)
        {
            await presenter.VisualiseBasicAttack(m_Source, TotalDamage);
        }
    }
    public class BasicAttackBuilder : IAttackBuilder
    {
        private List<IAttack> attacks = new List<IAttack>();
        public IAttackBuilder Append(AttackSource src, float damage)
        {
            attacks.Add(new BasicAttack(src, damage));
            return this;
        }

        public IAttack Build()
        {
            return new BasicCompositeAttack(attacks);
        }
    }
    public class SkillfulEntity : IAutoBattlerEntity
    {
        public IEntityStats Stats { get; private set; }

        public IHealth Health { get; private set; }

        public List<IGameSkill> Skills;
        public SkillfulEntity(IHealth HP, IEntityStats stats, IEnumerable<IGameSkill> skills)
        {
            HP = Health;
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
            builder = builder.Append(AttackSource.Piercing, 10 + Stats.Strength);
            foreach (var S in Skills)
            {
                builder = S.AttackEnemy(builder);
            }
            return builder;
        }

        public IAttackBuilder GetAttackBuilder()
        {
            return new BasicAttackBuilder();
        }
    }
}
