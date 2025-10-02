namespace AutoBattler
{
    public class AttackDecorator : IAttackBuilder
    {
        private IAttackBuilder decorating;
        public AttackDecorator(IAttackBuilder decorating)
        {
            this.decorating = decorating;
        }

        public IEntityStats OpposingStats => decorating.OpposingStats;

        public IAttack Build()
        {
            return OnBuild(decorating);
        }

        public IAttackBuilder WithAttack(AttackAttributes attrs)
        {
            decorating = OnAttack(attrs, decorating);
            return this;
        }
        public IAttackBuilder WithAttackerStats(IEntityStats stats)
        {
            decorating = OnAttackerStats(stats, decorating);
            return this;
        }
        protected virtual IAttack OnBuild(IAttackBuilder decorated) => decorated.Build();
        protected virtual IAttackBuilder OnAttack(AttackAttributes attrs, IAttackBuilder decorated) => decorated.WithAttack(attrs);
        protected virtual IAttackBuilder OnAttackerStats(IEntityStats stats, IAttackBuilder decorated) => decorated.WithAttackerStats(stats);
    }
}
