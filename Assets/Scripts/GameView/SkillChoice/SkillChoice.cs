using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Repositories;
using System;

namespace Game.View
{
    public class SkillChoice: Choice
    {
        public SkillDescriptorSO Skill;
        public SkillChoice(Action act, SkillDescriptorSO skill): base(act)
        {
            Skill = skill;
        }
    }
}
