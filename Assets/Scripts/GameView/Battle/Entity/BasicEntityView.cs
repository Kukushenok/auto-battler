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
        [SerializeField] private Vector3 punchDir;
        [SerializeField] private MonoBehaviourView<string> nameView;
        [SerializeField] private MonoBehaviourProcess<BasicAttack> basicAttackProcess;
        [SerializeField] private float attackDuration = 0.5f;

        private SpriteRenderer currentPrefabInstance;
        public override async UniTask Die()
        {
            await DoHide();
        }

        protected override async UniTask DoHide()
        {
            if (currentPrefabInstance != null)
            {
                await UniTask.WhenAll(LMotion.Create(hideSettings).BindToColor(currentPrefabInstance).ToUniTask(), nameView.TryHide());
                Destroy(currentPrefabInstance.gameObject);
            }
            currentPrefabInstance = null;
            
        }

        protected override async UniTask DoInit(BattleEntitySkinSO value)
        {
            currentPrefabInstance = Instantiate(value.Skin, prefabTransform).GetComponent<SpriteRenderer>();
            currentPrefabInstance.color = inSettings.StartValue;
            await UniTask.WhenAll(
                nameView.TryInit(value.Name), 
                LMotion.Create(inSettings).BindToColor(currentPrefabInstance).ToUniTask()
                );
        }

        protected override UniTask DoUpdate(BattleEntitySkinSO value)
        {
            return InitValueAsync(value);
        }

        protected override async UniTask BasicAttack(AttackType src, float damage)
        {
            Vector3 dist = new Vector3(0.1f, 0.1f, 0);
            Debug.Log(damage);
            UniTask task;
            if (damage > 0)
            {
                task = LMotion.Punch.Create(currentPrefabInstance.transform.localPosition, punchDir, attackDuration)
                     .WithDampingRatio(attackSettings.DampingRatio * Mathf.Clamp(0, 1, 1 - damage / 10))
                     .WithFrequency(attackSettings.Frequency).BindToLocalPosition(currentPrefabInstance.transform).ToUniTask();
            }
            else
            {
                task = LMotion.Shake.Create(currentPrefabInstance.transform.localPosition, dist, attackDuration)
                     .WithDampingRatio(attackSettings.DampingRatio)
                     .WithFrequency(attackSettings.Frequency).BindToLocalPosition(currentPrefabInstance.transform).ToUniTask();
            }
            await UniTask.WhenAll(task, basicAttackProcess.Process(new BasicAttack(src, damage)));
        }

        protected override async UniTask OtherAttack(string animID, AttackType src, float damage)
        {
            Debug.Log(damage);
            await LMotion.Shake.Create(currentPrefabInstance.transform.localPosition, Vector3.one * 0.2f, 0.5f)
              .WithDampingRatio(attackSettings.DampingRatio * Mathf.Clamp(0, 5, 5 - damage / 2)).BindToLocalPosition(currentPrefabInstance.transform);
        }
    }
}
