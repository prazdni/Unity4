using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class Explosion : IExplosion
    {
        private float _explosionForce;
        private float _explosionRadius;

        public Explosion(float explosionForce, float explosionRadius)
        {
            _explosionForce = explosionForce;
            _explosionRadius = explosionRadius;
        }

        public void Explode(Vector3 position)
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(position, _explosionRadius, colliders);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce,
                        position, _explosionRadius);
                }
            }
        }
    }
}