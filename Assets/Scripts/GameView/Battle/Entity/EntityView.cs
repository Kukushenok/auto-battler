using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Repositories;
using System.Threading.Tasks;

namespace Game.View
{
    public abstract class EntityView: MonoBehaviourView<BattleEntitySkinSO>, IAttackPresenter
    {
        public Task VisualiseBasicAttack(AttackType src, float damage) => BasicAttack(src, damage).AsTask();
        public Task VisualiseOtherAttack(string animID, AttackType src, float damage) => OtherAttack(animID, src, damage).AsTask();
        protected abstract UniTask BasicAttack(AttackType src, float damage);
        protected abstract UniTask OtherAttack(string animID, AttackType src, float damage);
        public abstract UniTask Die();
    }
}
