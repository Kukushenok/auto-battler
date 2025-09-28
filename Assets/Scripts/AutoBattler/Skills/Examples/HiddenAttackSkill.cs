using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBattler.Skills
{
    public class HiddenAttackSkill: IGameSkill
    {
        class HiddenAttackDecorator: AttackDecorator
        {
            private float damageBonus;
            public HiddenAttackDecorator(IAttackBuilder decorating, float damageBonus): base(decorating)
            {
                this.damageBonus = damageBonus;
            }
            private bool triggers = false;

            protected override IAttack OnBuild(IAttackBuilder decorating)
            {
                if(triggers)
                {
                    decorating = decorating.WithAttack(AttackType.Ability, damageBonus);
                }
                return base.OnBuild(decorating);
            }

            protected override IAttackBuilder OnAttackerStats(IEntityStats stats, IAttackBuilder decorating)
            {
                if(OpposingStats.Dexterity < stats.Dexterity)
                {
                    triggers = true;
                }
                return base.OnAttackerStats(stats, decorating);
            }
        }
        private float damageBonus;
        public HiddenAttackSkill(float damageBonus)
        {
            this.damageBonus = damageBonus;
        }
        public IAttackBuilder ModifyEnemy(IAttackBuilder enemy) => new HiddenAttackDecorator(enemy, damageBonus);
    }
    public class PoisonSkill: IGameSkill
    {
        private int times = 0;
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr)
        {
            if(times > 0) bldr = bldr.WithAttack(AttackType.Ability, times);
            times++;
            return bldr;
        }
    }
}
