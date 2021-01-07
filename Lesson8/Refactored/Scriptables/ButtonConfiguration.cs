using UnityEngine;

namespace Unity4.Lesson8
{
    public class ButtonConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private DoorConfiguration _door;
        [SerializeField] private Vector3 _position;

        public Transform Prefab => _prefab;

        public Vector3 Position => _position;

        public DoorConfiguration Door => _door;
    }
}