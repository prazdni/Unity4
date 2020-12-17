using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonModel : IButtonModel
    {
        public Transform Transform { get; }
        public Vector3 Position { get; }
        public IDoorModel Door { get; }
        
        public ButtonModel(ButtonConfiguration button)
        {
            Transform = Object.Instantiate(button.Prefab, button.Position, Quaternion.identity);
            Position = button.Position;
            Door = new DoorModel(button.Door);
        }
    }
}