using UnityEngine;

namespace Lesson5.Decorator
{
    public readonly struct WeaponDefaultCharacteristics
    {
        public float Force { get; }
        public float Volume { get; }
        public AudioClip AudioClip { get; }
        public AudioSource AudioSource { get; }

        public WeaponDefaultCharacteristics(float force, float volume, AudioClip audioClip, AudioSource audioSource)
        {
            Force = force;
            Volume = volume;
            AudioClip = audioClip;
            AudioSource = audioSource;
        }
    }
}