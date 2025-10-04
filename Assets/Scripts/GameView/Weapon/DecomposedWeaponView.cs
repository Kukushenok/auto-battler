using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Repositories;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponView : MonoBehaviourView<WeaponSO>
    {
        [SerializeField] private MonoBehaviourView<float> Power;
        [SerializeField] private MonoBehaviourView<AttackType> attackType;
        [SerializeField] private MonoBehaviourView<string> weaponName;
        [SerializeField] private MonoBehaviorSection section;
        protected override async UniTask DoHide()
        {
            await UniTask.WhenAll(Power.TryHide(), attackType.TryHide(), weaponName.TryHide(), section.TryHide());
        }

        protected override async UniTask DoInit(WeaponSO value)
        {
            await UniTask.WhenAll(
                 Power.TryInit(value.Damage),
                 attackType.TryInit(value.Source),
                 weaponName.TryInit(value.Name),
                 section.TryShow()
             );
        }

        protected override async UniTask DoUpdate(WeaponSO value)
        {
            await UniTask.WhenAll(
                 Power.TryUpdate(value.Damage),
                 attackType.TryUpdate(value.Source),
                 weaponName.TryUpdate(value.Name)
             );
        }
    }
}
