using System;
using Unity4.Lesson6;
using UnityEngine;

namespace Asteroids
{
    public class ShipCollisionChecker
    {
        private IShip _ship;
        private ModifierManager _shipModifierManager;
        private bool _isInteracted;
        
        public ShipCollisionChecker(IShip ship)
        {
            _ship = ship;
            _shipModifierManager = new ModifierManager(ship);
            _isInteracted = false;
        }

        public bool IsCollision(Transform sceneObject)
        {
            var isInteracted = false;
            
            if ((_ship.ShipTransform.position - sceneObject.position).sqrMagnitude < Constants.CollisionDistance)
            {
                isInteracted = true;
                _ship.OnAction(sceneObject.transform);
                _shipModifierManager.ModifyShip();
            }

            return isInteracted;
        }

    }
}