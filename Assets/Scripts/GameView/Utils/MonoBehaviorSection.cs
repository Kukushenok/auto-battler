using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.View
{
    /// <summary>
    /// Life cycle is supposed to be:
    /// Init -> Hide
    /// </summary>
    public abstract class MonoBehaviorSection : MonoBehaviour
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
