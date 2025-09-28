namespace AutoBattler.Skills
{
    public class WarriorRushSkill: IGameSkill
    {
        private class DoubledownDecorator : AttackDecorator
        {
            public DoubledownDecorator(IAttackBuilder decorating) : base(decorating)
            {
            }
            protected override IAttackBuilder OnAttack(AttackType src, float damage, IAttackBuilder decorated)
            {
                if (src != AttackType.Ability)
                {
                    decorated = decorated.WithAttack(AttackType.Ability, damage);
                }
                return base.OnAttack(src, damage, decorated);
            }
        }
        public bool enabled = true;
        public IAttackBuilder ModifyEnemy(IAttackBuilder bldr)
        {
            if(enabled)
            {
                enabled = false;
                return new DoubledownDecorator(bldr);
            }
            return bldr;
        }
    }
}
