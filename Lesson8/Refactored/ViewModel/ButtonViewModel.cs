using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonViewModel : IButtonViewModel
    {
        private IButtonModel _button;
        private Animator _animator;
        
        public ButtonViewModel(IButtonModel button)
        {
            _button = button;
            _animator = _button.Door.Animator;
        }

        public void Interact(bool shouldActivate)
        {
            if (shouldActivate)
            {
                _animator.SetTrigger("Open");
            }
            else
            {
                _animator.SetTrigger("Close");
            }
        }
    }
}