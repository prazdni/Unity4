using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    [Serializable]
    public class Speed : ISpeed
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }
        public float RotationSpeed
        {
            get => _rotationSpeed;
            set => _rotationSpeed = value;
        }
    }
}