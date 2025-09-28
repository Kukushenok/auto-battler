using AutoBattler;
using Cysharp.Threading.Tasks;
using Game.Registries;
using Game.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public class SkillChooser: MonoBehaviour
    {
        [SerializeField] private MonoBehaviourView<SkillChoice> Prefab;
        [SerializeField] private Transform CoreTransform;
        [SerializeField] private MonoBehaviorSection WindowAnimator;
        private IRegistry<SkillDescriptorSO> descriptorRepo;

        public async UniTask<ISkillDescriptor> ChooseFrom(IEnumerable<ISkillDescriptor> skillDescriptors)
        {
            await WindowAnimator.Show();
            UniTaskCompletionSource<ISkillDescriptor> select = new UniTaskCompletionSource<ISkillDescriptor>();
            List<MonoBehaviourView<SkillChoice>> skillChoices = new List<MonoBehaviourView<SkillChoice>>();
            int i = 0;
            foreach(var descriptor in skillDescriptors)
            {
                var skill = descriptorRepo.Get(descriptor.ID);
                var view = Instantiate(Prefab, CoreTransform);
                skillChoices.Add(view);

                var choosingSkill = descriptor;
                await view.InitValueAsync(new SkillChoice(() => select.TrySetResult(choosingSkill), skill));
                i++;
            }
            var result = await select.Task;
            while(skillChoices.Count > 0)
            {
                await skillChoices[0].Hide();
                Destroy(skillChoices[0]);
                skillChoices.RemoveAt(0);
            }
            await WindowAnimator.Hide();
            return result;
        }
    }
}
