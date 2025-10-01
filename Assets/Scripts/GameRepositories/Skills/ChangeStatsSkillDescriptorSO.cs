using UnityEngine;
using AutoBattler;
using AutoBattler.Skills;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Stat Change Skill", menuName = "Scriptable Objects/Skills/Types/Stat Change Skill")]
    public class ChangeStatsSkillDescriptorSO : SkillDescriptorSO
    {
        [field: SerializeField] private int AddStrength;
        [field: SerializeField] private int AddDexterity;
        [field: SerializeField] private int AddEndurance;
        public override IGameSkill CreateSkill()
        {
            return new StatEditSkill(new EntityStats(AddStrength, AddDexterity, AddEndurance));
        }
    }
}
