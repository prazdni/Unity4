using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeModel : IGrenadeModel
    {
        public Transform Transform { get; }
        public float ThrowForce { get; }
        public float ExplosionForce { get; }
        public float ExplosionRadius { get; }
        public float Damage { get; }

        public GrenadeModel(Transform transform, float throwForce, float explosionForce, float explosionRadius, float damage)
        {
            Transform = transform;
            ThrowForce = throwForce;
            ExplosionForce = explosionForce;
            ExplosionRadius = explosionRadius;
            Damage = damage;
        }
    }
}