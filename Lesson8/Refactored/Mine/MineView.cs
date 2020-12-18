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
                _viewModel.SetDamageOnCollision();
            }
        }
    }
}