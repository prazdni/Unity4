using UnityEngine;

namespace Asteroids
{
    public class TransformCollisionAndReturnChecker : TransformReturnChecker
    {
        private IShip _ship;
        private Camera _camera;
        private ShipCollisionChecker _shipCollisionChecker;
        
        public TransformCollisionAndReturnChecker(IShip ship)
        {
            _ship = ship;
            _camera = Camera.main;
            _shipCollisionChecker = new ShipCollisionChecker(_ship);
        }

        public override bool ShouldReturn(Transform sceneObject)
        {
            var shouldReturn = false;
            
            if (_shipCollisionChecker.IsCollision(sceneObject))
            {
                shouldReturn = true;
            }
            else
            {
                var vec = _camera.WorldToViewportPoint(sceneObject.position);
                if (vec.x < 0 || vec.x > 1 || vec.y < 0 || vec.y > 1)
                {
                    shouldReturn = true;
                }
            }

            return shouldReturn;
        }
    }
}