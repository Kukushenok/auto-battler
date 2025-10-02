namespace AutoBattler
{
    internal class MissAttackDecorator : AttackDecorator
    {
        public MissAttackDecorator(IAttackBuilder bldr) : base(bldr)
        {
        }
        protected override IAttackBuilder OnAttack(AttackAttributes attrs, IAttackBuilder decorated)
        {
            if (attrs.IsMissable)
            {
                attrs = attrs.WithDamage(0);
            }
            return base.OnAttack(attrs, decorated);
        }
    }
}
