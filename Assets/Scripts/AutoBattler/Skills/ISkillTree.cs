namespace AutoBattler.External
{
    public interface ISkillTree
    {
        public string ID { get; }
        public bool IsExausted { get; }
        public int Level { get; }
        public float HealthBonus { get; }
        public string LabelName { get; }
        public ISkillDescriptor GetCurrentSkill();
        public IWeapon GetWeapon();
    }
}
