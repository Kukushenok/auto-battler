using AutoBattler;
using AutoBattler.External;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Repositories
{
    public class SkillLine : ISkillTree
    {
        private Queue<SkillDescriptorSO> line;
        private PlayerClassSkillBranch branch;
        public int Level { get; private set; }
        public SkillLine(PlayerClassSkillBranch br)
        {
            Level = 1;
            branch = br;
            line = new Queue<SkillDescriptorSO>(br.Skills);
        }

        public bool IsExausted => line.Count == 0;

        public float HealthBonus => branch.HealthBonus;

        public string LabelName => string.Format(branch.LabelFormat, Level);

        public string ID => branch.name;

        public ISkillDescriptor GetCurrentSkill()
        {
            if (line.TryPeek(out var result)) return result;
            return null;
        }

        public IWeapon GetWeapon()
        {
            return branch.StartingWeapon;
        }
        public void AddLevel()
        {
            line.Dequeue();
            Level++;
        }
    }
    class PlayerSkillLines : ISkillRepository
    {
        private SkillLine[] skillLines;
        private int limitLevel;
        public PlayerSkillLines(PlayerClassSkillBranch[] branches, int limitLevel)
        {
            skillLines = branches.Select(x => new SkillLine(x)).ToArray();
            this.limitLevel = limitLevel;
        }

        public void Choose(ISkillTree descriptor)
        {
            foreach (var Q in skillLines)
            {
                if (Q.ID == descriptor.ID)
                {
                    Q.AddLevel();
                    limitLevel--;
                    return;
                }
            }
            throw new InvalidOperationException("The skill should be from GetSkills operation");
        }

        IEnumerable<ISkillTree> ISkillRepository.GetSkillTrees()
        {
            if (limitLevel <= 0) yield break;
            foreach (var Q in skillLines)
            {
                yield return Q;
            }
        }
    }
}
