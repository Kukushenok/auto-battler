namespace AutoBattler
{
    public interface IHealth
    {
        public float HP { get; }
        public float MaxHP { get; }
        public bool IsDead { get; }
        internal void DoDamage(float damage);
    }
}
