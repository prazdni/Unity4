using System;
using UnityEngine;

namespace Asteroids
{
    public class ShipCollisionChecker
    {
        private IShip _ship;
        private bool _isInteracted;
        
        public ShipCollisionChecker(IShip ship)
        {
            _ship = ship;
            _isInteracted = false;
        }

        public bool IsCollision(IEnemy enemy)
        {
            var isInteracted = false;
            
            if ((_ship.ShipTransform.position - enemy.SceneEnemy.transform.position).sqrMagnitude < Constants.CollisionDistance)
            {
                isInteracted = true;
                _ship.OnAction.Invoke(enemy.SceneEnemy.transform);
            }

            return isInteracted;
        }

        public bool IsCollision(Transform sceneObject)
        {
            var isInteracted = false;
            
            if ((_ship.ShipTransform.position - sceneObject.position).sqrMagnitude < Constants.CollisionDistance)
            {
                isInteracted = true;
                _ship.OnAction.Invoke(sceneObject.transform);
            }

            return isInteracted;
        }

    }
}