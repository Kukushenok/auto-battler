using AutoBattler;
using AutoBattler.Skills;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Hidden Attack Skill", menuName = "Scriptable Objects/Skills/Types/Hidden Attack Skill")]
    public class HiddenAttackDescriptorSO : SkillDescriptorSO
    {
        [field: SerializeField] private float DamageBonus;
        public override IGameSkill CreateSkill()
        {
            return new HiddenAttackSkill(DamageBonus);
        }
    }
}
