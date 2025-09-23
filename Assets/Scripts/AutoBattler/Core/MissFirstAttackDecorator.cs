namespace AutoBattler
{
    internal class MissFirstAttackDecorator : IAttackBuilder
    {
        private IAttackBuilder bldr;
        public MissFirstAttackDecorator(IAttackBuilder bldr)
        {
            this.bldr = bldr;
        }

        public IAttackBuilder Append(AttackType src, float damage)
        {
            if(src != AttackType.Ability)
            {
                damage = 0;
            }
            bldr = bldr.Append(src, damage);
            return this;
        }

        public IAttack Build()
        {
            return bldr.Build();
        }
    }
}
