using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    public abstract class MonoBehaviourProcess<T> : MonoBehaviour, IViewProcess<T>
    {
        public abstract UniTask Process(T value);
    }
}
