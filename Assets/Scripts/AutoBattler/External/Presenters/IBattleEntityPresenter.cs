namespace AutoBattler.External
{
    public interface IBattleEntityPresenter
    {
        public IAttackPresenter AttackPresenter { get; }
        public void WithStats(IEntityStats stats);
        public void WithWeapon(IWeapon weapon);
        public void WithHealth(IHealth health);
        public void UseVisualModifier(string modifier);
        public void UseSkin(string skin);
    }
}
