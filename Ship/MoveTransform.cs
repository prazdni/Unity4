﻿using UnityEngine;

namespace Asteroids
{
    public class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        
        public float Speed { get; set; }

        protected MoveTransform()
        {
            
        }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.position += _move;
        }
    }
}