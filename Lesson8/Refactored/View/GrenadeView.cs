using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeView : MonoBehaviour, IInitialize<IExplosionViewModel>
    {
        private IExplosionViewModel _viewModel;
        
        public void Initialize(IExplosionViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _viewModel.Explode(transform.position);
            }
        }
    }
}