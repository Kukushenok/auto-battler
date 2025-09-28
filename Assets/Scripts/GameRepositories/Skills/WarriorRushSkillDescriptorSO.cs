using UnityEngine;
using AutoBattler;
using AutoBattler.Skills;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Warrior Rush Skill", menuName = "Scriptable Objects/Skills/Types/Warrior Rush Skill")]
    public class WarriorRushSkillDescriptorSO : SkillDescriptorSO
    {
        public override IGameSkill CreateSkill()
        {
            return new WarriorRushSkill();
        }
    }
}
