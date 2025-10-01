using Cysharp.Threading.Tasks;

namespace Game.View
{
    /// <summary>
    /// Life cycle is supposed to be:
    /// Init -> Update (multiple times) -> Hide 
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public interface IView<X>
    {
        public UniTask InitValueAsync(X value);
        public UniTask UpdateValue(X value);
        public UniTask Hide();
    }
}
