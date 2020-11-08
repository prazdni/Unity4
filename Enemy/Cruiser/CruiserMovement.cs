using UnityEngine;

namespace Asteroids
{
    public class CruiserMovement : IExecute
    {
        private IShip _ship;
        private Transform _sceneEnemy;
        private float _currentSpeed;
        
        public CruiserMovement(Transform sceneEnemy, float currentSpeed, IShip ship)
        {
            _sceneEnemy = sceneEnemy;
            _currentSpeed = currentSpeed;
            _ship = ship;
        }
        
        public void Execute(float deltaTime)
        {
            var enemyTransform = _sceneEnemy.transform;

            if ((enemyTransform.position - _ship.ShipTransform.position).sqrMagnitude > 10.0f )
            {
                enemyTransform.position += Vector3.up * (_currentSpeed * deltaTime);
            }
        }
    }
}