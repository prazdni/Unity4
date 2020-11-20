using Manager;
using UnityEngine;

namespace Asteroids
{
    public class InputController : IExecute
    {
        private IExecute _accelerationManager;
        private IExecute _rotationManager;
        private IExecute _moveManager;
        private IExecute _weaponController;

        public InputController(IShip ship, Transform bullet, Transform barrel, float force)
        {
            _weaponController = new ShipWeaponController(ship, bullet, barrel, force);
            _accelerationManager = new AccelerationManager(ship);
            _rotationManager = new RotationManager(ship);
            _moveManager = new MoveManager(ship);
        }

        public void Execute(float deltaTime)
        {
            _accelerationManager.Execute(deltaTime);
            _rotationManager.Execute(deltaTime);
            _moveManager.Execute(deltaTime);
            _weaponController.Execute(deltaTime);
        }
    }
}