using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class MonoBehavourScreen<T>: MonoBehaviourProcess<T>
    {
        [SerializeField] private MonoBehaviorSection section;
        [SerializeField] private MonoBehaviourView<T> resultView;
        [SerializeField] private MonoBehaviourView<Choice> choicer;
        public override async UniTask Process(T value)
        {
            await section.TryShow();
            await resultView.TryInit(value);
            await choicer.WaitForSelection();
            await UniTask.WhenAll(choicer.TryHide(), resultView.TryHide(), section.TryHide());
        }
    }
}
