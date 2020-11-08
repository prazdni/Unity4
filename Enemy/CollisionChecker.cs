using System;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidCollisionChecker : IExecute
    {
        private IShip _ship;
        private Transform _sceneEnemy;
        private IEnemy _enemy;
        private bool _isInteracted;
        
        public AsteroidCollisionChecker(Transform sceneEnemy, IEnemy enemy, IShip ship)
        {
            _ship = ship;
            _sceneEnemy = sceneEnemy;
            _enemy = enemy;
            _isInteracted = false;
        }

        public void Execute(float deltaTime)
        {
            if ((_ship.ShipTransform.position - _sceneEnemy.transform.position).sqrMagnitude < Constants.CollisionDistance)
            {
                _isInteracted = true;
                _ship.OnAction.Invoke(_sceneEnemy.transform);
                _enemy.OnAction.Invoke(_ship.ShipTransform);
            }
        }

        public void SetInteraction(bool isInteracted)
        {
            _isInteracted = isInteracted;
        }
    }
}