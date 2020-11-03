using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IShip
    {
        private readonly IMove _moveImplementation;
        private readonly IRotate _rotateImplementation;

        public float Speed => _moveImplementation.Speed;
        public Transform ShipTransform { get; private set; }

        public Ship(IMove moveImplementation, IRotate rotateImplementation, Transform shipTransform)
        {
            _moveImplementation = moveImplementation;
            _rotateImplementation = rotateImplementation;
            ShipTransform = shipTransform;
        }
        
        public void Move(float horizontal, float vectical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vectical, deltaTime);
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
    }
}