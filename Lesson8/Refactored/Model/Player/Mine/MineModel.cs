using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineModel : IMineModel
    {
        public Transform Transform { get; }
        public float ExplosionForce { get; }
        public float ExplosionRadius { get; }
        public float Damage { get; }
        public float Duration { get; }

        public MineModel(Transform transform, float explosionForce, float explosionRadius, float damage, float duration)
        {
            Transform = transform;
            ExplosionForce = explosionForce;
            ExplosionRadius = explosionRadius;
            Damage = damage;
            Duration = duration;
        }
    }
}