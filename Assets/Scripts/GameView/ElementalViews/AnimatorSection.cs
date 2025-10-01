using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorSection: ActiveTogglerSection
    {
        [SerializeField] private string setTrigger;
        private Animator anim;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        protected override async UniTask DoHide()
        {
            anim.SetTrigger(setTrigger);
            await UniTask.WaitForSeconds(stopDelay);
            gameObject.SetActive(false);
        }
    }
}
