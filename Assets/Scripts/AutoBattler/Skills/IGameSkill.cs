using AutoBattler.External;

namespace AutoBattler
{
    public interface IGameSkill
    {
        public IAttackBuilder ModifySelf(IAttackBuilder bldr) => bldr;
        public IAttackBuilder ModifyEnemy(IAttackBuilder bldr) => bldr;
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr) => bldr;
        public IEntityStats ModifySelfStats(IEntityStats stats) => stats;
        public void AddVisualEffects(IBattleEntityPresenter presenter) { }
    }
}
