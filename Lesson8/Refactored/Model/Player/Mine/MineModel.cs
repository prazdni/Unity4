using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineModel : IMineModel
    {
        public Transform Transform { get; }
        public float ExplosionForce { get; }
        public float ExplosionRadius { get; }
        public float Damage { get; }
        public int Quantity { get; }

        public MineModel(Transform transform, float explosionForce, float explosionRadius, float damage)
        {
            Transform = transform;
            ExplosionForce = explosionForce;
            ExplosionRadius = explosionRadius;
            Damage = damage;
        }
    }
}