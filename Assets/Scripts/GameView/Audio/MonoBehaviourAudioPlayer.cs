using UnityEngine;
using VContainer;

namespace Game.View.Audio
{
    public abstract class MonoBehaviourAudioPlayer : MonoBehaviour
    {
        protected IAudioManager Manager;
        [Inject]
        private void Construct(IAudioManager manager)
        {
            this.Manager = manager;
        }
    }
    public class BasicMonoBehaviourAudioPlayer : MonoBehaviourAudioPlayer
    {
        [field: SerializeField] private AudioDescriptor descriptor;
        public void Play()
        {
            Manager.Play(descriptor);
        }
    }
}
