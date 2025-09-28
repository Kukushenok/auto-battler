using UnityEngine;
using AutoBattler;
using AutoBattler.Skills;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Poison Skill", menuName = "Scriptable Objects/Skills/Types/Poison Skill")]
    public class PoisonSkillDescriptorSO : SkillDescriptorSO
    {
        public override IGameSkill CreateSkill()
        {
            return new PoisonSkill();
        }
    }
}
