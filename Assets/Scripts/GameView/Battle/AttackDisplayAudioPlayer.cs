using Game.View.Audio;
using UnityEngine;

namespace Game.View
{
    public class AttackDisplayAudioPlayer: MonoBehaviourAudioPlayer
    {
        [SerializeField] private AudioDescriptor normalAttack;
        [SerializeField] private AudioDescriptor failureAttack;
        public void OnAttack(float damage) => Manager.Play(damage > 0 ? normalAttack : failureAttack);
    }
}
