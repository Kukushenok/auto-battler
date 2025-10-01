using AutoBattler;
using AutoBattler.Skills;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Shield Skill", menuName = "Scriptable Objects/Skills/Types/Shield Skill")]
    public class ShieldSkillDescriptorSO : SkillDescriptorSO
    {
        [SerializeField] private float savingDamage = 3;
        public override IGameSkill CreateSkill()
        {
            return new ShieldSkill(savingDamage);
        }
    }
}
