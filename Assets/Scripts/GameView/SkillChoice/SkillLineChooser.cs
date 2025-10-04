using AutoBattler;
using AutoBattler.External;
using Cysharp.Threading.Tasks;
using Game.Registries;
using Game.Repositories;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.View
{
    public class SkillLineChooser : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourView<SkillTreeChoice> Prefab;
        [SerializeField] private Transform CoreTransform;
        [SerializeField] private MonoBehaviorSection WindowAnimator;
        private IObjectResolver instantiator;
        [Inject]
        private void Construct(IObjectResolver instr)
        {
            instantiator = instr;
        }


        public async UniTask<ISkillTree> ChooseFrom(IEnumerable<ISkillTree> skillTrees)
        {
            await WindowAnimator.Show();
            UniTaskCompletionSource<ISkillTree> select = new UniTaskCompletionSource<ISkillTree>();
            List<MonoBehaviourView<SkillTreeChoice>> skillChoices = new List<MonoBehaviourView<SkillTreeChoice>>();
            int i = 0;
            foreach (var tree in skillTrees)
            {
                var view = instantiator.Instantiate(Prefab, CoreTransform);
                skillChoices.Add(view);

                var choosingTree = tree;
                await view.InitValueAsync(new SkillTreeChoice(() => select.TrySetResult(choosingTree), choosingTree));
                i++;
            }
            var result = await select.Task;
            while (skillChoices.Count > 0)
            {
                await skillChoices[0].Hide();
                Destroy(skillChoices[0].gameObject);
                skillChoices.RemoveAt(0);
            }
            await WindowAnimator.Hide();
            return result;
        }
    }
}
