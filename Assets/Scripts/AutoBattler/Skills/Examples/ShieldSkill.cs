namespace AutoBattler.Skills
{
    public class ShieldSkill : IGameSkill
    {
        private class ShieldDecorator : AttackDecorator
        {
            private bool triggers = false;
            private float savingHP = 0;
            public ShieldDecorator(IAttackBuilder decorating, float saveHP) : base(decorating)
            {
                this.savingHP = saveHP;
            }

            protected override IAttack OnBuild(IAttackBuilder decorating)
            {
                if (triggers)
                {
                    // The Builder is responsible to set Damage to zero if the total damage is negative.
                    decorating = decorating.WithAttack(AttackType.Ability, -savingHP);
                }
                return base.OnBuild(decorating);
            }
            protected override IAttackBuilder OnAttackerStats(IEntityStats stats, IAttackBuilder decorating)
            {
                if (stats.Strength < OpposingStats.Strength)
                {
                    triggers = true;
                }
                return base.OnAttackerStats(stats, decorating);
            }
        }
        private float savingHP;
        public ShieldSkill(float savingHP)
        {
            this.savingHP = savingHP;
        }

        public IAttackBuilder ModifySelf(IAttackBuilder bldr) => new ShieldDecorator(bldr, savingHP);
    }
}
