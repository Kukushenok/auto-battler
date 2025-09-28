using Cysharp.Threading.Tasks;
using Game.Repositories;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponChoice : MonoBehaviourView<WeaponChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> choicer;
        [SerializeField] private MonoBehaviourView<float> weaponDamage;

        protected override UniTask DoHide()
        {
            return UniTask.WhenAll(
                choicer.TryHide(),
                weaponDamage.TryHide()
                );
        }

        protected override UniTask DoInit(WeaponChoice value)
        {
            return UniTask.WhenAll(
                 choicer.TryInit(value),
                 weaponDamage.TryInit(value.Weapon.Damage)
             );
        }

        protected override UniTask DoUpdate(WeaponChoice value)
        {
            return UniTask.WhenAll(
                choicer.TryUpdate(value),
                weaponDamage.TryUpdate(value.Weapon.Damage)
            );
        }
    }
}
