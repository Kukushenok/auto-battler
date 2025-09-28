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
                strength.TryHide(),
                dexterity.TryHide(),
                endurance.TryHide()
                );
        }

        public override UniTask InitValueAsync(IEntityStats value)
        {
            return UniTask.WhenAll(
                strength.TryInit(value.Strength),
                dexterity.TryInit(value.Dexterity),
                endurance.TryInit(value.Endurance)
                );
        }

        public override UniTask UpdateValue(IEntityStats value)
        {
            return UniTask.WhenAll(
                strength.TryUpdate(value.Strength),
                dexterity.TryUpdate(value.Dexterity),
                endurance.TryUpdate(value.Endurance)
                );
        }
    }
}
