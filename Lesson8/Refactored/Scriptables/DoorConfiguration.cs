using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    [Serializable]
    public class DoorConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _rotation;
        
        public Transform Prefab => _prefab;

        public Animator Animator => _animator;

        public Vector3 Position => _position;
        
        public Vector3 Rotation => _rotation;
    }
}