using UnityEngine;

namespace Asteroids
{
    public class CruiserMovement : IExecute
    {
        private IShip _ship;
        private IEnemy _enemy;
        private float _currentSpeed;
        
        public CruiserMovement(IEnemy enemy, float currentSpeed, IShip ship)
        {
            _enemy = enemy;
            _currentSpeed = currentSpeed;
            _ship = ship;
        }
        
        public void Execute(float deltaTime)
        {
            var enemyTransform = _enemy.SceneEnemy;

            if ((enemyTransform.position - _ship.ShipTransform.position).sqrMagnitude > 10.0f )
            {
                enemyTransform.position += Vector3.up * (_currentSpeed * deltaTime);
            }
        }
    }
}