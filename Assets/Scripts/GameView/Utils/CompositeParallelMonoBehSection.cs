using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class CompositeParallelMonoBehSection : MonoBehaviorSection
    {
        [SerializeField] private MonoBehaviorSection[] allSections;

        protected override async UniTask DoHide()
        {
            await UniTask.WhenAll(from a in allSections select a.Hide());
        }

        protected override async UniTask DoShow()
        {
            await UniTask.WhenAll(from a in allSections select a.Show());
        }
    }
}
