namespace AutoBattler.Skills
{
    public class BarbarianRageSkill : IGameSkill
    {
        private float attackBonus;
        private float attackDebuff;
        private int rounds;
        public BarbarianRageSkill(float attackBonus, float attackDebuff, int rounds)
        {
            this.attackBonus = attackBonus;
            this.attackDebuff = attackDebuff;
            this.rounds = rounds;
        }
        public IAttackBuilder AttackEnemy(IAttackBuilder bldr)
        {
            bldr = bldr.WithAttack(new AttackAttributes(AttackType.Ability, rounds > 0 ? attackBonus : attackDebuff));
            if (rounds > 0) rounds--;
            return bldr;
        }
    }
}
