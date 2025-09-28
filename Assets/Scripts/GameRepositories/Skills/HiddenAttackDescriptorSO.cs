using UnityEngine;
using AutoBattler;
using AutoBattler.Skills;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Hidden Attack Skill", menuName = "Scriptable Objects/Skills/Hidden Attack Skill")]
    public class HiddenAttackDescriptorSO : SkillDescriptorSO
    {
        [field: SerializeField] private float DamageBonus;
        public override IGameSkill CreateSkill()
        {
            return new HiddenAttackSkill(DamageBonus);
        }
    }
}
