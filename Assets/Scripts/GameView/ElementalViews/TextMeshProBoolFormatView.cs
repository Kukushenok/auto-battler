using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class BoolToStringFormatterView : MonoBehaviourView<bool>
    {
        [SerializeField] private MonoBehaviourView<string> decorating;
        [SerializeField] private string trueValue;
        [SerializeField] private string falseValue;
        private string Value(bool x) => x ? trueValue : falseValue;
        protected override async UniTask DoHide()
        {
            await decorating.TryHide();
        }

        protected override async UniTask DoInit(bool value)
        {
            await decorating.TryInit(Value(value));
        }

        protected override async UniTask DoUpdate(bool value)
        {
            await decorating.TryUpdate(Value(value));
        }
    }
}
