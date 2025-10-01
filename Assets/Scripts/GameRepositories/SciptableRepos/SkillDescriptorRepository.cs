using UnityEngine;
using Game.Registries;
namespace Game.Repositories
{
    [CreateAssetMenu(fileName = "Skill Repository", menuName = "Scriptable Objects/Skills/Repository")]
    public class SkillDescriptorRepository: IdentifiableRegistry<SkillDescriptorSO>
    {

    }
}
