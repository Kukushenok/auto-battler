using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.View
{
    public static class ChoiceExtensions
    {
        public static async UniTask WaitForSelection(this IView<Choice> choice)
        {
            UniTaskCompletionSource src = new UniTaskCompletionSource();
            await choice.InitValueAsync(new Choice(() => src.TrySetResult()));
            await src.Task;
            await choice.Hide();
        }
        public static async UniTask<int> WaitForSelection(params IView<Choice>[] choices)
        {
            UniTaskCompletionSource<int> src = new UniTaskCompletionSource<int>();
            List<UniTask> tasks = new List<UniTask>();
            for(int i = 0; i < choices.Length; i++)
            {
                int dx = i;
                tasks.Add(choices[i].InitValueAsync(new Choice(() => src.TrySetResult(dx))));
            }
            await UniTask.WhenAll(tasks);
            var result = await src.Task;
            await UniTask.WhenAll(from s in choices select s.Hide());
            return result;
        }
    }
}
