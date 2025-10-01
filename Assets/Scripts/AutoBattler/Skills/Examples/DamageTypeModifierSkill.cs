namespace AutoBattler.Assets.Scripts.AutoBattler.Skills.Examples
{
    public class DamageTypeModifierSkill : IGameSkill
    {
        private class DamageTypeModifierDecorator : AttackDecorator
        {
            private AttackType type;
            private float multiplier;
            public DamageTypeModifierDecorator(IAttackBuilder decorating, AttackType type, float multiplier) : base(decorating)
            {
                this.type = type;
                this.multiplier = multiplier;
            }
            protected override IAttackBuilder OnAttack(AttackType src, float damage, IAttackBuilder decorated)
            {
                if (src == type)
                {
                    damage *= multiplier;
                }
                return base.OnAttack(src, damage, decorated);
            }
        }
        private AttackType type;
        private float multiplier;
        public DamageTypeModifierSkill(AttackType type, float multiplier)
        {
            this.type = type;
            this.multiplier = multiplier;
        }
        public IAttackBuilder ModifySelf(IAttackBuilder bldr) => new DamageTypeModifierDecorator(bldr, type, multiplier);
    }
    public class PeriodicDamageSkill : IGameSkill
    {
        private int frequency;
        private float bonusDamage;
        private int roundCounter;
        public PeriodicDamageSkill(int frequency, float bonusDamage)
        {
            this.frequency = frequency;
            this.bonusDamage = bonusDamage;
        }
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr)
        {
            roundCounter++;
            if (roundCounter == frequency)
            {
                bldr = bldr.WithAttack(AttackType.Ability, bonusDamage);
                roundCounter = 0;
            }
            return bldr;
        }
    }
}
