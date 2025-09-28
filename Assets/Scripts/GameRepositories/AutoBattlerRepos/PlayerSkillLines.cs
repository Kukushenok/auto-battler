using AutoBattler;
using AutoBattler.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Repositories
{
    public class SkillLine: ISkillTree
    {
        private Queue<SkillDescriptorSO> line;
        private IWeapon startingWeapon;
        public SkillLine(IEnumerable<SkillDescriptorSO> descriptors, IWeapon startingWeapon)
        {
            this.startingWeapon = startingWeapon;
            line = new Queue<SkillDescriptorSO>(descriptors);
        }

        public bool IsExausted => line.Count == 0;

        public ISkillDescriptor GetCurrentSkill()
        {
            if(line.TryPeek(out var result)) return result;
            return null;
        }

        public IWeapon GetStartingWeapon()
        {
            return startingWeapon;
        }
        public void AddLevel()
        {
            line.Dequeue();
        }
    }
    class PlayerSkillLines : ISkillRepository
    {
        private SkillLine[] skillLines;
        private int limitLevel;
        public PlayerSkillLines(PlayerClassSkillBranch[] branches, int limitLevel)
        {
            skillLines = new SkillLine[branches.Length];
            for (int i = 0; i < skillLines.Length; i++)
            {
                skillLines[i] = new SkillLine(branches[i].Skills, branches[i].StartingWeapon);
            }

            this.limitLevel = limitLevel;
        }

        public void Choose(ISkillTree descriptor)
        {
            foreach(var Q in skillLines)
            {
                if(Q == descriptor)
                {
                    Q.AddLevel();
                    limitLevel--;
                    return;
                }
            }
            throw new InvalidOperationException("The skill should be from GetSkills operation");
        }

        IEnumerable<ISkillTree> ISkillRepository.GetSkills()
        {
            if (limitLevel <= 0) yield break;
            foreach (var Q in skillLines)
            {
                yield return Q;
            }
        }
    }
}
