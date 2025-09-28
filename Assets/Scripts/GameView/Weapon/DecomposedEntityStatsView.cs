using AutoBattler;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedEntityStatsView : MonoBehaviourView<IEntityStats>
    {
        [SerializeField] private MonoBehaviourView<int> strength;
        [SerializeField] private MonoBehaviourView<int> dexterity;
        [SerializeField] private MonoBehaviourView<int> endurance;
        public override UniTask Hide()
        {
            return UniTask.WhenAll(
                strength?.Hide() ?? UniTask.CompletedTask,
                dexterity?.Hide() ?? UniTask.CompletedTask,
                endurance?.Hide() ?? UniTask.CompletedTask
                );
        }

        public override UniTask InitValueAsync(IEntityStats value)
        {
            return UniTask.WhenAll(
                strength?.InitValueAsync(value.Strength) ?? UniTask.CompletedTask,
                dexterity?.InitValueAsync(value.Dexterity) ?? UniTask.CompletedTask,
                endurance?.InitValueAsync(value.Endurance) ?? UniTask.CompletedTask
                );
        }

        public override UniTask UpdateValue(IEntityStats value)
        {
            return UniTask.WhenAll(
                strength?.UpdateValue(value.Strength) ?? UniTask.CompletedTask,
                dexterity?.UpdateValue(value.Dexterity) ?? UniTask.CompletedTask,
                endurance?.UpdateValue(value.Endurance) ?? UniTask.CompletedTask
                );
        }
    }
}
