using AutoBattler;
using Game.Registries;
using UnityEngine;
namespace Game.Repositories
{
    public abstract class SkillDescriptorSO : IdentifiableScriptableObject, ISkillDescriptor
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [System.Obsolete("Deprecated")]
        [field: SerializeField] public float HealthBonus { get; private set; }

        public abstract IGameSkill CreateSkill();
    }
}
