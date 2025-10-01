using Game.Registries;
using UnityEngine;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Repository", menuName = "Scriptable Objects/Skills/Repository")]
    public class SkillDescriptorRepository : IdentifiableRegistry<SkillDescriptorSO>
    {

    }
}
