using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonModel : IButtonModel
    {
        public Transform Transform { get; }
        public IDoorModel Door { get; }
        
        public ButtonModel(ButtonConfiguration button)
        {
            Transform = Object.Instantiate(button.Prefab);
            Door = new DoorModel(button.Door);
        }
    }
}