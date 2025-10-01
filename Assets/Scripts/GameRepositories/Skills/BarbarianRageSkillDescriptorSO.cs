using AutoBattler;
using AutoBattler.Skills;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Barbarian Range Skill", menuName = "Scriptable Objects/Skills/Types/Barbarian Rage Skill")]
    public class BarbarianRageSkillDescriptorSO : SkillDescriptorSO
    {
        [SerializeField] private float damageBuff = 2;
        [SerializeField] private float damageDebuff = -1;
        [SerializeField] private int rounds = 3;
        public override IGameSkill CreateSkill()
        {
            return new BarbarianRageSkill(damageBuff, damageDebuff, rounds);
        }
    }
}
