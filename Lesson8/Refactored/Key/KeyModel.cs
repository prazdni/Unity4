using UnityEngine;

namespace Unity4.Lesson8
{
    public class KeyModel : IKeyModel
    {
        public Transform Transform { get; }

        public KeyModel(KeyConfiguration key)
        {
            Transform = Object.Instantiate(key.Prefab);
        }
    }
}