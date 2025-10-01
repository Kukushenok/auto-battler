namespace AutoBattler
{
    public interface IWeapon
    {
        public string ID { get; }
        public AttackType Source { get; }
        public float Damage { get; }
    }
}
