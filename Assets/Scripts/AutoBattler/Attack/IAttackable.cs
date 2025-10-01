namespace AutoBattler
{
    public interface IAttackable
    {
        public IHealth Health { get; }
        public IAttackBuilder GetAttackBuilder();
    }
}
