using Game.View.Audio;
using UnityEngine;

namespace Game.View
{
    public class DexterityCheckAudioManager : MonoBehaviourAudioPlayer
    {
        [SerializeField] private AudioDescriptor roundSound;
        [SerializeField] private AudioDescriptor successSound;
        [SerializeField] private AudioDescriptor failSound;
        public void OnRound() => Manager.Play(roundSound);
        public void OnSuccess() => Manager.Play(successSound);
        public void OnFail() => Manager.Play(failSound);
    }
}
