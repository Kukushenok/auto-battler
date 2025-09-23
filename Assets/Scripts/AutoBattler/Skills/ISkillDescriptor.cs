using System.Collections;
using static UnityEditor.ObjectChangeEventStream;

namespace AutoBattler
{
    public interface ISkillDescriptor
    {
        public float HealthBonus { get; }
        public IGameSkill CreateSkill();
    }
}
