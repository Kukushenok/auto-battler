using AutoBattler.Utils;
using System;
using UnityEngine;
using VContainer.Unity;

namespace Game.View.Audio
{
    // this is far for ideal
    public class AudioSourceAudioManager : IAudioManager, IStartable, IDisposable
    {
        private AudioSource src;
        private IRandom rnd;
        public AudioSourceAudioManager(IRandom rnd)
        {
            this.rnd = rnd;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Play(AudioDescriptor audio)
        {

            src.pitch = rnd.GetRange(audio.PitchDeviation.x, audio.PitchDeviation.y);
            src.PlayOneShot(audio.Clip, rnd.GetRange(audio.VolumeDeviation.x, audio.VolumeDeviation.y));
        }

        public void Start()
        {
            src = new GameObject("AudioManager").AddComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(src.gameObject);
        }
    }
}
