namespace AutoBattler
{
    public interface IAttackBuilder
    {
        public IEntityStats OpposingStats { get; }
        public IAttackBuilder WithAttackerStats(IEntityStats stats) => this;
        public IAttackBuilder WithAttack(AttackType src, float damage);
        public IAttack Build();
    }
}
