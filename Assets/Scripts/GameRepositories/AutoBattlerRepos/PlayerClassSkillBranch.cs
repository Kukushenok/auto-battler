using System.Collections.Generic;
using UnityEngine;

namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Line", menuName = "Scriptable Objects/Skills/Branch/Class")]
    public class PlayerClassSkillBranch : ScriptableObject
    {
        [field: SerializeField] public List<SkillDescriptorSO> Skills { get; private set; }
        [field: SerializeField] public WeaponSO StartingWeapon { get; private set; }
    }
}
