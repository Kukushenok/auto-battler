using AutoBattler.External;
using Game.Repositories;
using System;

namespace Game.View
{
    public class SkillTreeChoice : Choice
    {
        public readonly ISkillTree SkillTree;
        public SkillTreeChoice(Action act, ISkillTree skillTree) : base(act)
        {
            SkillTree = skillTree;
        }
    }
}
