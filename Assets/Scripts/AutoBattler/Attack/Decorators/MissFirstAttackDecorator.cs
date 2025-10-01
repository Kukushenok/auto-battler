namespace AutoBattler
{
    internal class MissFirstAttackDecorator : AttackDecorator
    {
        public MissFirstAttackDecorator(IAttackBuilder bldr) : base(bldr)
        {
        }
        protected override IAttackBuilder OnAttack(AttackType src, float damage, IAttackBuilder decorated)
        {
            if (src != AttackType.Ability)
            {
                damage = 0;
            }
            return base.OnAttack(src, damage, decorated);
        }
    }
}
