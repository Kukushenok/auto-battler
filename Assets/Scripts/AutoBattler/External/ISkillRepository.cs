using System.Collections.Generic;

namespace AutoBattler.External
{
    public interface ISkillRepository
    {
        public IEnumerable<ISkillDescriptor> GetSkills();
        public void Choose(ISkillDescriptor descriptor);
    }
}
