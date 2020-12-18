using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineView : MonoBehaviour, IInitialize<IMineViewModel>
    {
        private IMineViewModel _viewModel;
        
        public void Initialize(IMineViewModel viewModel)
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
            Physics.OverlapSphereNonAlloc(position, _viewModel.ExplosionRadius, colliders);

            foreach (var coll in colliders)
            {
                if (coll.GetComponent<Rigidbody>() != null)
                {
                    coll.GetComponent<Rigidbody>().AddExplosionForce(_viewModel.ExplosionForce,
                        position, _viewModel.ExplosionRadius);
                }
            }
        }
    }
}