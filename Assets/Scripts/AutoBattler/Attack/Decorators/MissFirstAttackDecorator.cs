namespace AutoBattler
{
    internal class MissFirstAttackDecorator : IAttackBuilder
    {
        private IAttackBuilder bldr;
        public MissFirstAttackDecorator(IAttackBuilder bldr)
        {
            this.bldr = bldr;
        }

        public IEntityStats OpposingStats => bldr.OpposingStats;

        public IAttackBuilder WithAttack(AttackType src, float damage)
        {
            if(src != AttackType.Ability)
            {
                damage = 0;
            }
            bldr = bldr.WithAttack(src, damage);
            return this;
        }
        public IAttackBuilder WithAttackerStats(IEntityStats stats)
        {
            bldr = bldr.WithAttackerStats(stats);
            return this;
        }
        public IAttack Build()
        {
            return bldr.Build();
        }
    }
}
