using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IGrenadeModel
    {
        Transform Transform { get; }
        float ThrowForce { get; }
        float ExplosionForce { get; }
        float ExplosionRadius { get; }
        float Damage { get; }
    }
}