using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    [RequireComponent(typeof(Button))]
    public class ButtonChoiceView : MonoBehaviourView<Choice>
    {
        private Choice currentChoice;
        private Button btn;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnButtonDown);
        }
        private void OnDestroy()
        {
            if(btn != null) btn.onClick.RemoveListener(OnButtonDown);
        }
        public override UniTask Hide()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask InitValueAsync(Choice value)
        {
            currentChoice = value;
            return UniTask.CompletedTask;
        }

        public override UniTask UpdateValue(Choice value)
        {
            currentChoice = value;
            return UniTask.CompletedTask;
        }
        private void OnButtonDown()
        {
            currentChoice?.Select();
            currentChoice = null;
        }
    }
}
