using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ExplosionViewModel : IExplosionViewModel
    {
        private List<Vector3> _allWayPoints;
        private float _explosionForce;
        private float _explosionRadius;
        private float _damage;

        public ExplosionViewModel(float explosionForce, float explosionRadius, float damage)
        {
            _explosionForce = explosionForce;
            _explosionRadius = explosionRadius;
            _damage = damage;
        }

        public void Explode(Vector3 position)
        {
            Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    if (coll.gameObject.CompareTag("Enemy"))
                    {
                        //coll.gameObject.GetComponent<MyEnemy>().Hurt(_damage);
                    }

                    coll.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce,
                        position, _explosionRadius);
                }
            }
        }
    }
}