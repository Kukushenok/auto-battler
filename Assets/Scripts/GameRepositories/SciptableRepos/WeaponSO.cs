using UnityEngine;
using Game.Registries;
using AutoBattler;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon/Object")]
    public class WeaponSO : IdentifiableScriptableObject, IWeapon
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public AttackType Source { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }

    }
}
