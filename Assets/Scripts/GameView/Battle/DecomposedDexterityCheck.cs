using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedDexterityCheck : MonoBehaviourView<DexterityCheck>
    {
        [SerializeField] private MonoBehaviourView<int> wanted;
        [SerializeField] private MonoBehaviourView<int> got;
        protected override UniTask DoHide()
        {
            return UniTask.WhenAll(
                wanted.TryHide(),
                got.TryHide()
                );
        }

        protected override UniTask DoInit(DexterityCheck value)
        {
            return UniTask.WhenAll(
                wanted.TryInit(value.Wanted),
                got.TryInit(value.Got)
                );
        }

        protected override UniTask DoUpdate(DexterityCheck value)
        {
            return UniTask.WhenAll(
                wanted.TryUpdate(value.Wanted),
                got.TryUpdate(value.Got)
                );
        }
    }
}
