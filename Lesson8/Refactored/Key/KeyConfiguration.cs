using UnityEngine;

namespace Unity4.Lesson8
{
    public class KeyConfiguration
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private Vector3 _position;

        public Transform Prefab => _prefab;

        public Vector3 Position => _position;
    }
}