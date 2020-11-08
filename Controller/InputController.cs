using Manager;
using UnityEngine;

namespace Asteroids
{
    public class InputController : IExecute
    {
        private IExecute _accelerationManager;
        private IExecute _rotationManager;
        private IExecute _moveManager;
        private IExecute _fireManager;

        public InputController(IShip ship, Rigidbody2D bullet, Transform barrel, float force)
        {
            _fireManager = new FireManager(bullet, barrel, force);
            _accelerationManager = new AccelerationManager(ship);
            _rotationManager = new RotationManager(ship);
            _moveManager = new MoveManager(ship);
        }

        public void Execute(float deltaTime)
        {
            _accelerationManager.Execute(deltaTime);
            _rotationManager.Execute(deltaTime);
            _moveManager.Execute(deltaTime);
            _fireManager.Execute(deltaTime);
        }
    }
}