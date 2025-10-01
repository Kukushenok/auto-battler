using Game.Repositories;
using System;

namespace Game.View
{
    public class SkillChoice : Choice
    {
        public readonly SkillDescriptorSO Skill;
        public SkillChoice(Action act, SkillDescriptorSO skill) : base(act)
        {
            Skill = skill;
        }
    }
}
