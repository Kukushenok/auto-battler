using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public class TextMeshProDexterityCheck : MonoBehaviourView<DexterityCheck>
    {

        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Color successColor;
        [SerializeField] private Color failureColor;
        [SerializeField] private Color transparent = new Color(0, 0, 0, 0);
        [SerializeField] private float roundSpeed = 0.2f;
        [SerializeField] private int rounds = 4;
        [SerializeField] private float fadeInOutSpeed = 0.5f;
        [SerializeField] private Vector3 positionDiffer;
        [SerializeField] private float finalRoundSpeed = 0.5f;
        private void Awake()
        {
            text.color = transparent;
        }
        protected override async UniTask DoHide()
        {
            await LMotion.Create(text.color, transparent, fadeInOutSpeed).BindToColor(text).ToUniTask();
        }

        protected override async UniTask DoInit(DexterityCheck value)
        {
            await UniTask.WhenAll(
                LMotion.Create(transparent, failureColor, fadeInOutSpeed).BindToColor(text).ToUniTask(),
                SetRnd(value)
            );
        }

        protected override UniTask DoUpdate(DexterityCheck value)
        {
            // it is unnesesary
            text.text = value.Got.ToString();
            return UniTask.CompletedTask;
        }
        protected async UniTask SetRnd(DexterityCheck value)
        {
            for (int i = 0; i < rounds; i++)
            {
                text.text = ((i % value.Got) + 1).ToString();
                await LMotion.Punch.Create(text.transform.localScale, Vector3.one * 0.2f, roundSpeed).BindToLocalScale(text.transform).ToUniTask();
            }
            text.text = value.Got.ToString();
            if(!value.IsSuccessful)
            {
                await LMotion.Shake.Create(text.transform.localPosition, positionDiffer, finalRoundSpeed).BindToLocalPosition(text.transform).ToUniTask();
            }
            else
            {
                await UniTask.WhenAll(
                     LMotion.Create(text.color, successColor, fadeInOutSpeed).BindToColor(text).ToUniTask(),
                     LMotion.Punch.Create(text.transform.localPosition, positionDiffer, finalRoundSpeed).BindToLocalPosition(text.transform).ToUniTask()
                    );
            }
        }
    }
}
