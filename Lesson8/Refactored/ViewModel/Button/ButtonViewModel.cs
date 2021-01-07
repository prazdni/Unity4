using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonViewModel : IButtonViewModel
    {
        private Animator _animator;
        
        public ButtonViewModel(IButtonModel button)
        {
            _animator = button.Door.Animator;
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