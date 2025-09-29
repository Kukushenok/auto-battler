using Cysharp.Threading.Tasks;

namespace Game.View
{
    /// <summary>
    /// Represents a full view life cycle
    /// </summary>
    public interface IViewProcess<X>
    {
        public UniTask Process(X value);
    }
}
