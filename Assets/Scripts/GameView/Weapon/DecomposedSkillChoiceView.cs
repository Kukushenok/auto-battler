using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedSkillChoiceView : MonoBehaviourView<SkillChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> Choicer;
        [SerializeField] private MonoBehaviourView<string> Name;
        public override UniTask Hide()
        {
            return UniTask.WhenAll(
                Choicer.TryHide(),
                Name.TryHide()
             );
        }

        public override UniTask InitValueAsync(SkillChoice value)
        {
            return UniTask.WhenAll(
                    Choicer.TryInit(value),
                    Name.TryInit(value.Skill.Name)
            );
        }

        public override UniTask UpdateValue(SkillChoice value)
        {
            return UniTask.WhenAll(
                Choicer.TryUpdate(value),
                Name.TryUpdate(value.Skill.Name)
            );
        }
    }
}
