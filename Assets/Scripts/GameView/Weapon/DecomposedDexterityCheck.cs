using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedDexterityCheck : MonoBehaviourView<DexterityCheck>
    {
        [SerializeField] private MonoBehaviourView<int> wanted;
        [SerializeField] private MonoBehaviourView<int> got;
        public override UniTask Hide()
        {
            return UniTask.WhenAll(
                wanted.TryHide(),
                got.TryHide()
                );
        }

        public override UniTask InitValueAsync(DexterityCheck value)
        {
            return UniTask.WhenAll(
                wanted.TryInit(value.Wanted),
                got.TryInit(value.Got)
                );
        }

        public override UniTask UpdateValue(DexterityCheck value)
        {
            return UniTask.WhenAll(
                wanted.TryUpdate(value.Wanted),
                got.TryUpdate(value.Got)
                );
        }
    }
}
