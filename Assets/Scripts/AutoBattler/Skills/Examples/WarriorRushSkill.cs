namespace AutoBattler.Skills
{
    public class WarriorRushSkill : IGameSkill
    {
        private class DoubledownDecorator : AttackDecorator
        {
            private bool enabled = true;
            public DoubledownDecorator(IAttackBuilder decorating) : base(decorating)
            {
            }
            protected override IAttackBuilder OnAttack(AttackAttributes attrs, IAttackBuilder decorated)
            {
                decorated = base.OnAttack(attrs, decorated);
                if (attrs.Type != AttackType.Ability && enabled)
                {
                    decorated = decorated.WithAttack(attrs.WithTypeAndDamage(AttackType.Ability, attrs.Damage));
                    enabled = false;
                }
                return decorated;
            }
        }
        public bool enabled = true;
        public IAttackBuilder ModifyEnemy(IAttackBuilder bldr)
        {
            if (enabled)
            {
                enabled = false;
                return new DoubledownDecorator(bldr);
            }
            return bldr;
        }
    }
}
