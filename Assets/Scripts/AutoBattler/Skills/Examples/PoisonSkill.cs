namespace AutoBattler.Skills
{
    public class PoisonSkill: IGameSkill
    {
        private int times = 0;
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr)
        {
            if(times > 0) bldr = bldr.WithAttack(AttackType.Ability, times);
            times++;
            return bldr;
        }
    }
}
