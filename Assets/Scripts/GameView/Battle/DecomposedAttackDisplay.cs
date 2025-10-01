using AutoBattler;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public class BasicAttack
    {
        public readonly AttackType Type;
        public readonly float Damage;
        public BasicAttack(AttackType type, float damage)
        {
            Type = type;
            Damage = damage;
        }
    }
    public class DecomposedAttackDisplay : MonoBehaviourView<BasicAttack>
    {
        [SerializeField] private MonoBehaviourView<AttackType> attackType;
        [SerializeField] private MonoBehaviourView<float> attackDamageView;

        protected override async UniTask DoHide()
        {
            await UniTask.WhenAll(attackType.TryHide(), attackDamageView.TryHide());
        }

        protected override async UniTask DoInit(BasicAttack value)
        {
            await UniTask.WhenAll(attackType.TryInit(value.Type), attackDamageView.TryInit(value.Damage));
        }

        protected override async UniTask DoUpdate(BasicAttack value)
        {
            await UniTask.WhenAll(attackType.TryUpdate(value.Type), attackDamageView.TryUpdate(value.Damage));
        }
    }
}
