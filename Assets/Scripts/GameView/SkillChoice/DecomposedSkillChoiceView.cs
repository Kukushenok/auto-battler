using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedSkillChoiceView : MonoBehaviourView<SkillChoice>
    {
        [SerializeField] private MonoBehaviourView<Choice> Choicer;
        [SerializeField] private MonoBehaviourView<string> Name;
        protected override UniTask DoHide()
        {
            return UniTask.WhenAll(
                Choicer.TryHide(),
                Name.TryHide()
             );
        }

        protected override UniTask DoInit(SkillChoice value)
        {
            return UniTask.WhenAll(
                    Choicer.TryInit(value),
                    Name.TryInit(value.Skill.Name)
            );
        }

        protected override UniTask DoUpdate(SkillChoice value)
        {
            return UniTask.WhenAll(
                Choicer.TryUpdate(value),
                Name.TryUpdate(value.Skill.Name)
            );
        }
    }
}
