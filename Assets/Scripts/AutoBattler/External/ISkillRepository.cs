using System.Collections.Generic;

namespace AutoBattler.External
{
    public interface ISkillTree
    {
        public bool IsExausted { get; }
        public ISkillDescriptor GetCurrentSkill();
        public IWeapon GetStartingWeapon();
    }
    public interface ISkillRepository
    {
        public IEnumerable<ISkillTree> GetSkills();
        public void Choose(ISkillTree descriptor);
    }
}
