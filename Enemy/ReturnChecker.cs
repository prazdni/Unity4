using UnityEngine;

namespace Asteroids
{
    public class ReturnChecker
    {
        private IShip _ship;
        private Camera _camera;
        private CollisionChecker _collisionChecker;
        
        public ReturnChecker(IShip ship)
        {
            _ship = ship;
            _camera = Camera.main;
            _collisionChecker = new CollisionChecker(_ship);
        }

        public bool ShouldReturn(Transform sceneObject)
        {
            var shouldReturn = false;
            
            if (_collisionChecker.IsCollision(sceneObject))
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
        
        public bool ShouldReturn(IEnemy enemy)
        {
            var shouldReturn = false;
            
            if (_collisionChecker.IsCollision(enemy))
            {
                shouldReturn = true;
            }
            else
            {
                var vec = _camera.WorldToViewportPoint(enemy.SceneEnemy.position);
                if (vec.x < 0 || vec.x > 1 || vec.y < 0 || vec.y > 1)
                {
                    shouldReturn = true;
                }
            }

            return shouldReturn;
        }
    }
}