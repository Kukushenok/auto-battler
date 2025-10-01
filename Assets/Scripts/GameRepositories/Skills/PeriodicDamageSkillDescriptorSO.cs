using UnityEngine;
using AutoBattler;
using AutoBattler.Assets.Scripts.AutoBattler.Skills.Examples;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Periodic Damage Skill", menuName = "Scriptable Objects/Skills/Types/Periodic Damage Skill")]
    public class PeriodicDamageSkillDescriptorSO : SkillDescriptorSO
    {
        [SerializeField] private int frequency;
        [SerializeField] private float bonusDamage;
        public override IGameSkill CreateSkill()
        {
            return new PeriodicDamageSkill(frequency, bonusDamage);
        }
    }
}
