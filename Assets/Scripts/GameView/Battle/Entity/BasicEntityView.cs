using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Repositories;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace Game.View
{
    public class BasicEntityView : EntityView
    {
        [SerializeField] private SerializableMotionSettings<Color, NoOptions> inSettings;
        [SerializeField] private ShakeOptions attackSettings;
        [SerializeField] private SerializableMotionSettings<Color, NoOptions> hideSettings;
        [SerializeField] private Transform prefabTransform;

        private SpriteRenderer currentPrefabInstance;
        public override async UniTask Die()
        {
            if (currentPrefabInstance != null)
                await LMotion.Create(hideSettings).BindToColor(currentPrefabInstance).ToUniTask();
            Destroy(currentPrefabInstance.gameObject);
            currentPrefabInstance = null;
            SetHidden();
        }

        protected override async UniTask DoHide()
        {
            if(currentPrefabInstance != null)
                await LMotion.Create(hideSettings).BindToColor(currentPrefabInstance).ToUniTask();
            Destroy(currentPrefabInstance.gameObject);
            currentPrefabInstance = null;

        }

        protected override async UniTask DoInit(BattleEntitySkinSO value)
        {
            currentPrefabInstance = Instantiate(value.Skin, prefabTransform).GetComponent<SpriteRenderer>();
            await LMotion.Create(inSettings).BindToColor(currentPrefabInstance).ToUniTask();
        }

        protected override UniTask DoUpdate(BattleEntitySkinSO value)
        {
            return InitValueAsync(value);
        }

        protected override async UniTask BasicAttack(AttackType src, float damage)
        {
            Debug.Log(damage);
            await LMotion.Shake.Create(currentPrefabInstance.transform.localPosition, Vector3.one * 0.2f, 0.5f)
                 .WithDampingRatio(attackSettings.DampingRatio * Mathf.Clamp(0, 5, 5 - damage)).BindToLocalPosition(currentPrefabInstance.transform);
        }

        protected override async UniTask OtherAttack(string animID, AttackType src, float damage)
        {
            Debug.Log(damage);
            await LMotion.Shake.Create(currentPrefabInstance.transform.localPosition, Vector3.one * 0.2f, 0.5f)
              .WithDampingRatio(attackSettings.DampingRatio * Mathf.Clamp(0, 5, 5 - damage / 2)).BindToLocalPosition(currentPrefabInstance.transform);
        }
    }
}
