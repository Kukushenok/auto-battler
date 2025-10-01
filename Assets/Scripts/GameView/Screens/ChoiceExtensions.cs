using Cysharp.Threading.Tasks;

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
    }
}
