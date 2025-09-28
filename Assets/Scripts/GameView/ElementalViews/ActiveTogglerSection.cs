using Cysharp.Threading.Tasks;

namespace Game.View
{
    public class ActiveTogglerSection : MonoBehaviorSection
    {
        public override UniTask Hide()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }

        public override UniTask Show()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }
    }
}
