using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMineModel
    {
        Transform Transform { get; }
        float ExplosionForce { get; }
        float ExplosionRadius { get; }
        float Damage { get; }
    }
}