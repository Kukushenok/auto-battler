using UnityEngine;
using AutoBattler;
using AutoBattler.Skills;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Stone Skin Skill", menuName = "Scriptable Objects/Skills/Types/Stone Skin Skill")]
    public class StoneSkinSkillDescriptorSO : SkillDescriptorSO
    {
        public override IGameSkill CreateSkill()
        {
            return new StoneSkinSkill();
        }
    }
}
