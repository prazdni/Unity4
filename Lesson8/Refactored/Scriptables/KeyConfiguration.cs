using UnityEngine;

namespace Unity4.Lesson8
{
    public class KeyConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;

        public Transform Prefab => _prefab;
    }
}