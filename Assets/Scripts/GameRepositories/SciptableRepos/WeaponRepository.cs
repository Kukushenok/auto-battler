using UnityEngine;
using Game.Registries;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Weapon Repository", menuName = "Scriptable Objects/Weapon/Repository")]
    public class WeaponRepository : IdentifiableRegistry<WeaponSO>
    {

    }
}
