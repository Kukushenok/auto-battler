using System.Collections.Generic;

namespace AutoBattler.External
{
    public interface ISkillRepository
    {
        public IEnumerable<ISkillTree> GetSkillTrees();
        public void Choose(ISkillTree descriptor);
    }
}
