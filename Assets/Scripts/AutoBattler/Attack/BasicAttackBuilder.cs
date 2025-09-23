using System.Collections.Generic;

namespace AutoBattler
{
    public class BasicAttackBuilder : IAttackBuilder
    {
        private List<IAttack> attacks = new List<IAttack>();
        public IAttackBuilder Append(AttackType src, float damage)
        {
            attacks.Add(new BasicAttack(src, damage));
            return this;
        }

        public IAttack Build()
        {
            return new BasicCompositeAttack(attacks);
        }
    }
}
