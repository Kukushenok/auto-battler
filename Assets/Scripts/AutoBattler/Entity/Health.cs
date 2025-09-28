namespace AutoBattler
{
    public class Health : IHealth
    {
        public float MaxHP { get; private set; }

        public bool IsDead { get => HP <= 0; }

        public float HP { get; private set; }

        void IHealth.DoDamage(float damage)
        {
            this.HP -= damage;
        }

        public void ResetHealth()
        {
            this.HP = this.MaxHP;
        }

        public Health(float HP)
        {
            MaxHP = HP;
            this.HP = HP;
        }
    }
}
