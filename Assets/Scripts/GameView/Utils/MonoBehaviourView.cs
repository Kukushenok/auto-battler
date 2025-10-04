using Cysharp.Threading.Tasks;

namespace Game.View
{

    public abstract class MonoBehaviourView<X> : MonoBehaviourProcess<X>, IView<X>, IViewProcess<X>
    {
        public enum State { Initting, Initted, Hiding, Hidden }
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

        public sealed override async UniTask Process(X value)
        {
            if (state != State.Hidden) return;
            await InitValueAsync(value);
            await Hide();
        }
    }
}
