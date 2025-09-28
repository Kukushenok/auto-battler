using AutoBattler;
using AutoBattler.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Repositories
{
    class PlayerSkillLines : ISkillRepository
    {
        private Queue<SkillDescriptorSO>[] skillLines;
        public PlayerSkillLines(Queue<SkillDescriptorSO>[] skills)
        {
            skillLines = skills;
        }
        public void Choose(ISkillDescriptor descriptor)
        {
            foreach(var Q in skillLines)
            {
                if (Q.TryPeek(out SkillDescriptorSO so))
                {
                    if(so.ID == descriptor.ID)
                    {
                        Q.Dequeue();
                        return;
                    }
                }
            }
            throw new InvalidOperationException("The skill should be from GetSkills operation");
        }

        public IEnumerable<ISkillDescriptor> GetSkills()
        {
            foreach(var Q in skillLines)
            {
                if (Q.TryPeek(out SkillDescriptorSO so))
                {
                    yield return so;
                }
            }
        }
    }
}
