namespace AutoBattler.Skills
{
    public class ShieldSkill: IGameSkill
    {
        private class ShieldDecorator : AttackDecorator
        {
            private bool triggers = false;
            private float savingHP = 0;
            private float damageCounter = 0;
            public ShieldDecorator(IAttackBuilder decorating, float saveHP) : base(decorating)
            {
                this.savingHP = saveHP;
            }

            protected override IAttack OnBuild(IAttackBuilder decorating)
            {
                if (triggers)
                {
                    if (damageCounter <= savingHP) savingHP = damageCounter;
                    decorating = decorating.WithAttack(AttackType.Ability, -savingHP);
                }
                return base.OnBuild(decorating);
            }
            /// <summary>
            /// TODO: the damageCounter would count even the cancelled damage down the pipeline,
            /// so it is not idenpotent and 100% accurate. Rewrite if nessesary
            /// </summary>
            protected override IAttackBuilder OnAttack(AttackType src, float damage, IAttackBuilder decorated)
            {
                damageCounter += damage;
                return base.OnAttack(src, damage, decorated);
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
