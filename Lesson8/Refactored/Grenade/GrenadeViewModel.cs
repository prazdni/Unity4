using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeViewModel : IExplosionViewModel
    {
        public event Action<Vector3> OnCollision = v => { };
        
        public float DamageObj { get; }
        
        private IGrenadeModel _grenade;

        public GrenadeViewModel(IGrenadeModel grenade)
        {
            _grenade = grenade;
            DamageObj = grenade.Damage;
        }
        
        public void Explode(Vector3 position)
        {
            OnCollision.Invoke(position);
            Explosion(position);
            _grenade.Transform.gameObject.SetActive(false);
        }
        
        private void Explosion(Vector3 position)
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(position, _grenade.ExplosionRadius, colliders);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_grenade.ExplosionForce,
                        position, _grenade.ExplosionRadius);
                }
            }
        }
    }
}