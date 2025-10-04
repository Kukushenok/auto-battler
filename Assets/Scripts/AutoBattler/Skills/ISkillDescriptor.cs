namespace AutoBattler
{
    public interface ISkillDescriptor
    {
        public string ID { get; }
        public IGameSkill CreateSkill();
    }
}
