using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Unity4.Lesson8
{
    public class ButtonConstruct
    {
        public ButtonConstruct(ButtonConfiguration button)
        {
            IButtonModel buttonModel = new ButtonModel(button);
            
            IButtonViewModel buttonViewModel = new ButtonViewModel(buttonModel);
            
            foreach (var buttonView in Object.FindObjectsOfType<ButtonView>())
            {
                buttonView.Initialize(buttonViewModel);
            }
        }
    }
}