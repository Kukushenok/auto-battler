using AutoBattler;

namespace Game.View
{
    public struct HealthStats
    {
        public float HP;
        public float MaxHP;
        public HealthStats(IHealth hp)
        {
            HP = hp.HP;
            MaxHP = hp.MaxHP;
        }
    }
}
