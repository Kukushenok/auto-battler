using UnityEngine;

namespace Game.View.Audio
{
    [CreateAssetMenu(fileName = "Audio Descriptor", menuName = "Scriptable Objects/Audio/Descriptor")]
    public class AudioDescriptor: ScriptableObject
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public Vector2 VolumeDeviation { get; private set; } = Vector2.one;
        [field: SerializeField] public Vector2 PitchDeviation { get; private set; } = Vector2.one;
    }
}
