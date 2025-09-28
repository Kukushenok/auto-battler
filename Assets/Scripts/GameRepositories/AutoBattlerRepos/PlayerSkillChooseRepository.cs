using AutoBattler.External;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Line Definition", menuName = "Scriptable Objects/Skills/Branch/Repository")]
    public class PlayerSkillChooseRepository: ScriptableObject
    {
        [SerializeField] private PlayerClassSkillBranch[] SkillSets;
        
        public ISkillRepository CreateRepo()
        {
            return new PlayerSkillLines(SkillSets);
        }
    }
}
