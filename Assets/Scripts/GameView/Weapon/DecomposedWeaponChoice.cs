using AutoBattler;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponChoice : MonoBehaviourView<WeaponChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> choicer;
        [SerializeField] private MonoBehaviourView<float> weaponDamage;
        [SerializeField] private MonoBehaviourView<AttackType> attackType;
        [SerializeField] private MonoBehaviourView<string> weaponName;
        [SerializeField] private MonoBehaviorSection section;

        protected override UniTask DoHide()
        {
            return UniTask.WhenAll(
                choicer.TryHide(),
                weaponDamage.TryHide(),
                attackType.TryHide(),
                weaponName.TryHide(),
                section.Hide()
                );
        }

        protected override UniTask DoInit(WeaponChoice value)
        {
            return UniTask.WhenAll(
                 choicer.TryInit(value),
                 weaponDamage.TryInit(value.Weapon.Damage),
                 attackType.TryInit(value.Weapon.Source),
                 weaponName.TryInit(value.Weapon.Name),
                 section.Show()
             );
        }

        protected override UniTask DoUpdate(WeaponChoice value)
        {
            return UniTask.WhenAll(
                choicer.TryUpdate(value),
                weaponDamage.TryUpdate(value.Weapon.Damage),
                attackType.TryUpdate(value.Weapon.Source),
                weaponName.TryUpdate(value.Weapon.Name)
            );
        }
    }
}
