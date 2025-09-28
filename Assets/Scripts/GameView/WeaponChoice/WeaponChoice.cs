using Game.Repositories;
using System;

namespace Game.View
{
    public class WeaponChoice : Choice
    {
        public WeaponSO Weapon;
        public WeaponChoice(Action onChoosing, WeaponSO weapon) : base(onChoosing)
        {
            Weapon = weapon;
        }
    }
}
