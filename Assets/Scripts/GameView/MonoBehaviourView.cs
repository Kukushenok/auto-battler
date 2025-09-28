using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
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
        public enum State { Initting, Initted, Hiding, Hidden}
        private State state = State.Hidden;
        public async UniTask InitValueAsync(X value)
        {
            if (state != State.Hidden) return;
            state = State.Initting;
            await DoInit(value);
            state = State.Initted;
        }
        protected abstract UniTask DoInit(X value);
        public async UniTask UpdateValue(X value)
        {
            if (state != State.Initted) return;
            await DoUpdate(value);
        }
        protected abstract UniTask DoUpdate(X value);
        protected abstract UniTask DoHide();
        public async UniTask Hide()
        {
            if (state != State.Initted) return;
            state = State.Hiding;
            await DoHide();
            state = State.Hidden;
        }
    }
    /// <summary>
    /// Life cycle is supposed to be:
    /// Init -> Hide
    /// </summary>
    public abstract class MonoBehaviorSection: MonoBehaviour
    {
        public enum State { Initting, Initted, Hiding, Hidden }
        private State state = State.Hidden;
        public async UniTask Show()
        {
            if (state != State.Hidden) return;
            state = State.Initting;
            await DoShow();
            state = State.Initted;
        }
        public async UniTask Hide()
        {
            if (state != State.Initted) return;
            state = State.Hiding;
            await DoHide();
            state = State.Hidden;
        }
        protected abstract UniTask DoShow();
        protected abstract UniTask DoHide();
    }
}
