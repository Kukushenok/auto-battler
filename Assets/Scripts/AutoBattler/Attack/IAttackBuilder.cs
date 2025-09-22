namespace AutoBattler
{
    public interface IAttackBuilder
    {
        public IAttackBuilder Append(AttackSource src, float damage);
        public IAttack Build();
    }
}
