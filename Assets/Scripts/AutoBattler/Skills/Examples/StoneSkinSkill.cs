namespace AutoBattler.Skills
{
    public class StoneSkinSkill: IGameSkill
    {
        public IAttackBuilder ModifySelf(IAttackBuilder bldr)
        {
            return bldr.WithAttack(AttackType.Ability, -bldr.OpposingStats.Endurance);
        }
    }
}
