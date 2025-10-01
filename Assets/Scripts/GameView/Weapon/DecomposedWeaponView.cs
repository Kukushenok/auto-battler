using Cysharp.Threading.Tasks;
using Game.Repositories;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponView : MonoBehaviourView<WeaponSO>
    {
        [SerializeField] private MonoBehaviourView<float> Power;
        protected override async UniTask DoHide()
        {
            await Power.Hide();
        }

        protected override async UniTask DoInit(WeaponSO value)
        {
            await Power.InitValueAsync(value.Damage);
        }

        protected override async UniTask DoUpdate(WeaponSO value)
        {
            await Power.UpdateValue(value.Damage);
        }
    }
}
