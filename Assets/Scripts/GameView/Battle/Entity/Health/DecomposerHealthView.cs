using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposerHealthView : MonoBehaviourView<HealthStats>
    {
        [SerializeField] private MonoBehaviourView<float> health;
        [SerializeField] private MonoBehaviourView<float> maxHealth;

        protected override async UniTask DoHide()
        {
            await UniTask.WhenAll(
                health.TryHide(),
                maxHealth.TryHide()
            );
        }

        protected override async UniTask DoInit(HealthStats value)
        {
            await UniTask.WhenAll(
                health.TryInit(value.HP),
                maxHealth.TryInit(value.MaxHP)
            );
        }
        protected override async UniTask DoUpdate(HealthStats value)
        {
            await UniTask.WhenAll(
                health.TryUpdate(value.HP),
                maxHealth.TryUpdate(value.MaxHP)
            );
        }
    }
}
