using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposerHealthView: MonoBehaviourView<HealthStats>
    {
        [SerializeField] private MonoBehaviourView<float> health;
        [SerializeField] private MonoBehaviourView<float> maxHealth;

        public override async UniTask Hide()
        {
            await UniTask.WhenAll(
                health?.Hide() ?? UniTask.CompletedTask,
                maxHealth?.Hide() ?? UniTask.CompletedTask
            );
        }

        public override async UniTask InitValueAsync(HealthStats value)
        {
            await UniTask.WhenAll(
                health?.InitValueAsync(value.HP) ?? UniTask.CompletedTask, 
                maxHealth?.InitValueAsync(value.MaxHP) ?? UniTask.CompletedTask
            );
        }
        public override async UniTask UpdateValue(HealthStats value)
        {
            await UniTask.WhenAll(
                health?.UpdateValue(value.HP) ?? UniTask.CompletedTask, 
                maxHealth?.UpdateValue(value.MaxHP) ?? UniTask.CompletedTask
            );
        }
    }
}
