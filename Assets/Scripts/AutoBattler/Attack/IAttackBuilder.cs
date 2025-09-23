namespace AutoBattler
{
    public interface IAttackBuilder
    {
        public IAttackBuilder Append(AttackType src, float damage);
        public IAttack Build();
    }
}
