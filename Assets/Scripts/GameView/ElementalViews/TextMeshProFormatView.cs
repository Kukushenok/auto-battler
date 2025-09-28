using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using TMPro;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextMeshProFormatView<T>: MonoBehaviourView<T>
    {
        [SerializeField] private Color baseColor = Color.white;
        [SerializeField] private Color transparent = new Color(0, 0, 0, 0); 
        [SerializeField] private string format = "{0}";
        private TextMeshProUGUI text;
        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            text.color = transparent;
        }
        public override async UniTask Hide()
        {
            await LMotion.Create(baseColor, transparent, 0.5f).WithEase(Ease.InSine).BindToColor(text).ToUniTask();
        }

        public override async UniTask InitValueAsync(T value) 
        {
            text.text = string.Format(format, value);
            var x = LMotion.Create(transparent, baseColor, 0.5f).WithEase(Ease.InSine).BindToColor(text).ToUniTask();
            var y = LMotion.Punch.Create(1.0f, 0.2f, 0.25f).WithFrequency(20)
                    .WithDampingRatio(0f).Bind(x => transform.localScale = Vector3.one * x).ToUniTask();
            await UniTask.WhenAll(x, y);
        }

        public override async UniTask UpdateValue(T value)
        {
            text.text = string.Format(format, value);
            await LMotion.Punch.Create(1.0f, 0.2f, 0.25f).WithFrequency(20)
                .WithDampingRatio(0f).Bind(x => transform.localScale = Vector3.one * x).ToUniTask();
        }
    }
}
