using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class ColorTransitionSection: MonoBehaviorSection
    {
        [SerializeField] private float durationTime;
        private Color transparent = new Color(0, 0, 0, 0);
        private Color normalColor;
        private Image img;
        private void Awake()
        {
            img = GetComponent<Image>();
            normalColor = img.color;
            img.color = transparent;
        }
        protected override async UniTask DoHide()
        {
            await LMotion.Create(normalColor, transparent, durationTime).WithEase(Ease.InOutCubic).Bind(x=>img.color = x).ToUniTask();
            gameObject.SetActive(false);
        }

        protected override async UniTask DoShow()
        {
            gameObject.SetActive(true);
            await LMotion.Create(transparent, normalColor, durationTime).WithEase(Ease.InOutCubic).Bind(x => img.color = x).ToUniTask();
        }


    }
}
