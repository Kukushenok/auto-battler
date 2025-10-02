using System.Collections.Generic;

namespace AutoBattler
{
    public class BasicAttackBuilder : IAttackBuilder
    {
        private List<IAttack> attacks = new List<IAttack>();
        public BasicAttackBuilder(IEntityStats myself)
        {
            OpposingStats = myself;
        }
        public IEntityStats OpposingStats { get; private set; }

        public IAttackBuilder WithAttack(AttackAttributes attrs)
        {
            attacks.Add(attrs);
            return this;
        }

        public IAttack Build()
        {
            return new BasicCompositeAttack(attacks);
        }
    }
}
