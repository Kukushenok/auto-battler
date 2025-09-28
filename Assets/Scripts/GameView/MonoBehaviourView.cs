using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public interface IView<X>
    {
        public UniTask InitValueAsync(X value);
        public UniTask UpdateValue(X value);
        public UniTask Hide();
    }
    /// <summary>
    /// Life cycle is supposed to be:
    /// Init -> Update (multiple times) -> Hide 
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public abstract class MonoBehaviourView<X>: MonoBehaviour, IView<X>
    {
        public abstract UniTask InitValueAsync(X value);
        public abstract UniTask UpdateValue(X value);
        public abstract UniTask Hide();
    }
    /// <summary>
    /// Life cycle is supposed to be:
    /// Init -> Hide
    /// </summary>
    public abstract class MonoBehaviorSection: MonoBehaviour
    {
        public abstract UniTask Show();
        public abstract UniTask Hide();
    }
}
