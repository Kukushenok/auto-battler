using AutoBattler;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    [Serializable]
    public struct WeaponAttackSpriteMapper
    {
        [SerializeField] private Sprite abilitySprite;
        [SerializeField] private Sprite crushingSprite;
        [SerializeField] private Sprite piercingSprite;
        [SerializeField] private Sprite choppingSprite;
        public Sprite Get(AttackType type) => type switch
        {
            AttackType.Piercing => piercingSprite,
            AttackType.Crushing => crushingSprite,
            AttackType.Chopping => choppingSprite,
            AttackType.Ability => abilitySprite,
            _ => null,
        };
    }
    [RequireComponent(typeof(Image))]
    public class WeaponAttackView : MonoBehaviourView<AttackType>
    {
        private Color transparent = new Color(0, 0, 0, 0);
        private Color normalColor;
        private Image img;
        [SerializeField] private WeaponAttackSpriteMapper spriteMapper;
        private void Awake()
        {
            img = GetComponent<Image>();
            normalColor = img.color;
            img.color = transparent;
        }
        protected override async UniTask DoHide()
        {
            await LMotion.Create(normalColor, transparent, 0.5f).WithEase(Ease.InSine).BindToColor(img).ToUniTask();
        }

        protected override async UniTask DoInit(AttackType value)
        {
            img.sprite = spriteMapper.Get(value);
            await UniTask.WhenAll(
            LMotion.Create(transparent, normalColor, 0.5f).WithEase(Ease.InSine).BindToColor(img).ToUniTask(),
            LMotion.Punch.Create(1.0f, 0.2f, 0.25f).WithFrequency(20)
                    .WithDampingRatio(0f).Bind(x => transform.localScale = Vector3.one * x).ToUniTask()
                    );
        }

        protected override async UniTask DoUpdate(AttackType value)
        {
            img.sprite = spriteMapper.Get(value);
            await LMotion.Punch.Create(1.0f, 0.2f, 0.25f).WithFrequency(20)
                .WithDampingRatio(0f).Bind(x => transform.localScale = Vector3.one * x).ToUniTask();
        }
    }
}
