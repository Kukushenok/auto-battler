using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class ActiveTogglerSection : MonoBehaviorSection
    {
        [SerializeField] protected float startDelay = 0.0f;
        [SerializeField] protected float stopDelay = 0.0f;
        protected override async UniTask DoHide()
        {
            await UniTask.WaitForSeconds(stopDelay);
            gameObject.SetActive(false);

        }

        protected override async UniTask DoShow()
        {
            await UniTask.WaitForSeconds(startDelay);
            gameObject.SetActive(true);
        }
    }
}
