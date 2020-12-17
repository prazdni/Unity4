using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonView : MonoBehaviour, IInitialize<IButtonViewModel>
    {
        private IButtonViewModel _buttonViewModel;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("CubeToThrow"))
            {
                _buttonViewModel.Interact(true);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("CubeToThrow"))
            {
                _buttonViewModel.Interact(false);
            }
        }

        public void Initialize(IButtonViewModel viewModel)
        {
            _buttonViewModel = viewModel;
        }
    }
}