using AutoBattler.External;
using UnityEngine;

namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Line Definition", menuName = "Scriptable Objects/Skills/Branch/Repository")]
    public class PlayerSkillChooseRepository : ScriptableObject
    {
        [SerializeField] private PlayerClassSkillBranch[] skillSets;
        [SerializeField] private int limitLevel = 3;
        public ISkillRepository CreateRepo()
        {
            return new PlayerSkillLines(skillSets, limitLevel);
        }
    }
}
