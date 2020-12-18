using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IExplosion
    {
        void SetExplosionParameters(float explosionForce, float explosionRadius);
        void Explode(Vector3 position);
    }
}