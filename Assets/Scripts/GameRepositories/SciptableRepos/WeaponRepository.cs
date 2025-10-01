using Game.Registries;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Weapon Repository", menuName = "Scriptable Objects/Weapon/Repository")]
    public class WeaponRepository : IdentifiableRegistry<WeaponSO>
    {

    }
}
