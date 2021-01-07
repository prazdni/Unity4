using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineViewModel : IExplosionViewModel
    {
        public event Action<Vector3> OnCollision = v => { };
        
        public float DamageObj { get; }

        private IMineModel _mine;

        public MineViewModel(IMineModel mine)
        {
            _mine = mine;
            DamageObj = mine.Damage;
        }
        
        public void Explode(Vector3 position)
        {
            OnCollision.Invoke(position);
            Explosion(position);
            _mine.Transform.gameObject.SetActive(false);
        }
        
        private void Explosion(Vector3 position)
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(position, _mine.ExplosionRadius, colliders);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_mine.ExplosionForce,
                        position, _mine.ExplosionRadius);
                }
            }
        }
    }
}