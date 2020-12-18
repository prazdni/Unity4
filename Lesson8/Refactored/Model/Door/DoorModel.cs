using UnityEngine;

namespace Unity4.Lesson8
{
    public class DoorModel : IDoorModel
    {
        public Transform Transform { get; }
        public Animator Animator { get; }
        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
        
        public DoorModel(DoorConfiguration door)
        {
            Rotation = door.Rotation;
            Quaternion rotation = Quaternion.Euler(Rotation);

            Animator = door.Animator;

            Position = door.Position;
            
            Transform = Object.Instantiate(door.Prefab, Position, rotation);
        }
    }
}