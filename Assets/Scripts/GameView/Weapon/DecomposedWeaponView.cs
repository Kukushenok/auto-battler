using Cysharp.Threading.Tasks;
using Game.Repositories;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedWeaponView : MonoBehaviourView<WeaponSO>
    {
        [SerializeField] private MonoBehaviourView<float> Power;
        public override async UniTask Hide()
        {
            await Power.Hide();
        }

        public override async UniTask InitValueAsync(WeaponSO value)
        {
            await Power.InitValueAsync(value.Damage);
        }

        public override async UniTask UpdateValue(WeaponSO value)
        {
            await Power.UpdateValue(value.Damage);
        }
    }
}
