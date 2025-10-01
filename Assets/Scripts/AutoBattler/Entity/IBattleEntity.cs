using AutoBattler.External;

namespace AutoBattler
{
    public interface IBattleEntity : IAttacker, IAttackable
    {
        public IEntityStats Stats { get; }
        public IWeapon Weapon { get; }
        public void Visualize(IBattleEntityPresenter presenter);
    }
}
