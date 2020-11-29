using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IShip
    {
        private readonly IMove _moveImplementation;
        private readonly IRotate _rotateImplementation;
        private Health _health;

        public float Speed
        {
            get => _moveImplementation.Speed;
            set
            {
                if (value > 0)
                {
                    _moveImplementation.Speed = value;
                }
            }
        }
        
        public float Health
        {
            get => _health.Current;
            set
            {
                if (_health.Current - value > 0)
                {
                    _health.ChangeCurrentHealth(value);
                }
            }
        }
        
        public Transform ShipTransform { get; }

        public event Action<Transform> ShipAction = delegate(Transform transform) {  };
        

        public Ship(IMove moveImplementation, IRotate rotateImplementation, Transform shipTransform)
        {
            _health = new Health(10.0f);
            _moveImplementation = moveImplementation;
            _rotateImplementation = rotateImplementation;
            ShipTransform = shipTransform;
            
            ShipAction += OnAction;
        }
        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }
        
        public void Rotation(Vector3 direction)
        {
            _rotateImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void OnAction(Transform transform)
        {
            ShipAction.Invoke(transform);
        }
    }
}