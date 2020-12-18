using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeView : MonoBehaviour, IInitialize<IExplosionViewModel<IGrenadeModel>>
    {
        private IExplosionViewModel<IGrenadeModel> _viewModel;
        
        public void Initialize(IExplosionViewModel<IGrenadeModel> viewModel)
        {
            _viewModel = viewModel;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _viewModel.SetDamageOnCollision(transform.position);
            }
            
            Explode(transform.position);
        }

        private void Explode(Vector3 position)
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(position, _viewModel.DamageObj.ExplosionRadius, colliders);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_viewModel.DamageObj.ExplosionForce,
                        position, _viewModel.DamageObj.ExplosionRadius);
                }
            }
        }
    }
}