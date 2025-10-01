namespace AutoBattler
{
    public interface IAttacker
    {
        public IAttackBuilder DoAttack(IAttackBuilder builder);
    }
}
