using UnityEngine;

namespace Unity4.Lesson8
{
    public class KeyModel : IKeyModel
    {
        public Transform Transform { get; }
        public Vector3 Position { get; }

        public KeyModel(KeyConfiguration key)
        {
            Position = key.Position;
            Transform = Object.Instantiate(key.Prefab, Position,Quaternion.identity);
        }
    }
}