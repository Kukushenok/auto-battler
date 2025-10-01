using Cysharp.Threading.Tasks;

namespace Game.View
{
    public class ActiveTogglerSection : MonoBehaviorSection
    {
        protected override UniTask DoHide()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }

        protected override UniTask DoShow()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }
    }
}
