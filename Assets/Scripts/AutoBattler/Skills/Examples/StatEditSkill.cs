namespace AutoBattler.Skills
{
    /// <summary>
    /// TODO: IT IS NOT A DECORATOR, BUT IT MIGHT BE.
    /// </summary>
    public class StatEditSkill : IGameSkill
    {
        private IEntityStats delta;
        public StatEditSkill(IEntityStats delta)
        {
            this.delta = delta;
        }

        public IEntityStats ModifySelfStats(IEntityStats stats)
        {
            return new EntityStats(stats.Strength + delta.Strength, stats.Dexterity + delta.Dexterity, stats.Endurance + delta.Endurance);
        }
    }
}
