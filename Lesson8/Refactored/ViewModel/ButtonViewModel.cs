using System;

namespace Unity4.Lesson8
{
    public class ButtonViewModel : IButtonViewModel
    {
        private IButtonModel _button;
        
        public ButtonViewModel(IButtonModel button)
        {
            _button = button;
        }

        public void Interact(bool shouldActivate)
        {
            if (shouldActivate)
            {
                //_button.Door.Animator.Play();
            }
            else
            {
                //
            }
        }
    }
}