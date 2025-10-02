using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Repositories;
using System.Threading.Tasks;

namespace Game.View
{
    public abstract class EntityView : MonoBehaviourView<BattleEntitySkinSO>, IAttackPresenter
    {
        public Task VisualiseBasicAttack(AttackAttributes attrs) => BasicAttack(attrs.Type, attrs.Damage).AsTask();
        public Task VisualiseOtherAttack(string animID, AttackAttributes attrs) => OtherAttack(animID, attrs.Type, attrs.Damage).AsTask();
        protected abstract UniTask BasicAttack(AttackType src, float damage);
        protected abstract UniTask OtherAttack(string animID, AttackType src, float damage);
        public abstract UniTask Die();
    }
}
