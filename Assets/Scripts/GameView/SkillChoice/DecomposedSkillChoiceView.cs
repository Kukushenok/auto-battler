using Cysharp.Threading.Tasks;
using Game.Repositories;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class DecomposedSkillView : MonoBehaviourView<SkillDescriptorSO>
    {
        [SerializeField] private MonoBehaviourView<string> Name;
        [SerializeField] private MonoBehaviourView<string> Description;
        [SerializeField] private MonoBehaviorSection Section;
        protected override UniTask DoHide()
        {
            return UniTask.WhenAll(
                Name.TryHide(),
                Description.TryHide(),
                Section.TryHide()
             );
        }

        protected override UniTask DoInit(SkillDescriptorSO value)
        {
            return UniTask.WhenAll(
                    Name.TryInit(value.Name),
                    Description.TryInit(value.Description),
                    Section.TryShow()
            );
        }

        protected override UniTask DoUpdate(SkillDescriptorSO value)
        {
            return UniTask.WhenAll(
                Name.TryUpdate(value.Name),
                Description.TryUpdate(value.Description)
            );
        }
    }
}
