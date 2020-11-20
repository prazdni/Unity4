using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IShip
    {
        private readonly IMove _moveImplementation;
        private readonly IRotate _rotateImplementation;

        public float Speed => _moveImplementation.Speed;
        public Transform ShipTransform { get; private set; }

        public Action<Transform> OnAction
        {
            get;
            private set;
        }

        public Ship(IMove moveImplementation, IRotate rotateImplementation, Transform shipTransform)
        {
            OnAction += OnTransformAction;
            _moveImplementation = moveImplementation;
            _rotateImplementation = rotateImplementation;
            ShipTransform = shipTransform;
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

        private void OnTransformAction(Transform actionObject)
        {
            Debug.Log("Interacted!");
        }

        public void SubscribeOnAction(Action<Transform> action)
        {
            OnAction += action;
        }
    }
}