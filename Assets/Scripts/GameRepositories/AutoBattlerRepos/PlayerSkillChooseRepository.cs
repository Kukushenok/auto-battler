using AutoBattler.External;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Line Definition", menuName = "Scriptable Objects/Skills/Skill Line Definition")]
    public class PlayerSkillChooseRepository: ScriptableObject
    {
        [Serializable]
        private struct SkillSet
        {
            public List<SkillDescriptorSO> Skills;
            public WeaponSO StartingWeapon;
        }
        [SerializeField] private SkillSet[] SkillSets;
        
        public ISkillRepository CreateRepo()
        {
            Queue<SkillDescriptorSO>[] queues = new Queue<SkillDescriptorSO>[SkillSets.Length];
            for(int i = 0; i < queues.Length; i++)
            {
                queues[i] = new Queue<SkillDescriptorSO>(SkillSets[i].Skills);
            }
            return new PlayerSkillLines(queues);
        }
    }
}
