using Cysharp.Threading.Tasks;

namespace Game.View
{
    public static class DecomposeViewExtensions
    {
        public static UniTask TryHide<T>(this MonoBehaviorSection sx)
        {
            return sx ? sx.Hide() : UniTask.CompletedTask;
        }
        public static UniTask TryShow<T>(this MonoBehaviorSection sx)
        {
            return sx ? sx.Show() : UniTask.CompletedTask;
        }
        public static UniTask TryHide<T>(this MonoBehaviourView<T> tsk)
        {
            return tsk ? tsk.Hide() : UniTask.CompletedTask;
        }
        public static UniTask TryInit<T>(this MonoBehaviourView<T> tsk, T value)
        {
            return tsk ? tsk.InitValueAsync(value) : UniTask.CompletedTask;
        }
        public static UniTask TryUpdate<T>(this MonoBehaviourView<T> tsk, T value)
        {
            return tsk ? tsk.UpdateValue(value) : UniTask.CompletedTask;
        }
    }
}
