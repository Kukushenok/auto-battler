using Cysharp.Threading.Tasks;
using Game.Repositories;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponChoice : MonoBehaviourView<WeaponChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> choicer;
        [SerializeField] private MonoBehaviourView<float> weaponDamage;

        public override UniTask Hide()
        {
            return UniTask.WhenAll(
                choicer.TryHide(),
                weaponDamage.TryHide()
                );
        }

        public override UniTask InitValueAsync(WeaponChoice value)
        {
            return UniTask.WhenAll(
                 choicer.TryInit(value),
                 weaponDamage.TryInit(value.Weapon.Damage)
             );
        }

        public override UniTask UpdateValue(WeaponChoice value)
        {
            return UniTask.WhenAll(
                choicer.TryUpdate(value),
                weaponDamage.TryUpdate(value.Weapon.Damage)
            );
        }
    }
}
