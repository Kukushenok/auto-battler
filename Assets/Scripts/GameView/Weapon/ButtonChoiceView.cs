using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    [RequireComponent(typeof(Button))]
    public class ButtonChoiceView : MonoBehaviourView<Choice>
    {
        [SerializeField] private MonoBehaviorSection section;
        private Choice currentChoice;
        private Button btn;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnButtonDown);
        }
        private void OnDestroy()
        {
            if (btn != null) btn.onClick.RemoveListener(OnButtonDown);
        }
        protected override UniTask DoHide()
        {
            return section.TryHide();
        }

        protected override UniTask DoInit(Choice value)
        {
            currentChoice = value;
            return section.TryShow();
        }

        protected override UniTask DoUpdate(Choice value)
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
