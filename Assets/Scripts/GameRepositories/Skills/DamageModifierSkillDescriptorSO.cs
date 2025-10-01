using AutoBattler;
using AutoBattler.Assets.Scripts.AutoBattler.Skills.Examples;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Damage Modifier Skill", menuName = "Scriptable Objects/Skills/Types/Damage Modifier Skill")]
    public class DamageModifierSkillDescriptorSO : SkillDescriptorSO
    {
        [SerializeField] private AttackType type;
        [SerializeField] private float multiplier;
        public override IGameSkill CreateSkill()
        {
            return new DamageTypeModifierSkill(type, multiplier);
        }
    }
}
