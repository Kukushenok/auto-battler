namespace AutoBattler.Skills
{
    public class StoneSkinSkill : IGameSkill
    {
        private class StoneSkinDecorator : AttackDecorator
        {
            private float savingHP = 0;
            public StoneSkinDecorator(IAttackBuilder decorating, float saveHP) : base(decorating)
            {
                this.savingHP = saveHP;
            }

            protected override IAttack OnBuild(IAttackBuilder decorating)
            {
                decorating = decorating.WithAttack(AttackAttributes.SkillDamage(-savingHP));
                return base.OnBuild(decorating);
            }
        }
        public IAttackBuilder ModifySelf(IAttackBuilder bldr)
        {
            return new StoneSkinDecorator(bldr, bldr.OpposingStats.Endurance);
        }
    }
}
