using UnityEngine;

namespace Asteroids
{
    public class BulletReturnChecker
    {
        private IShip _ship;
        private Camera _camera;
        
        public BulletReturnChecker(IShip ship)
        {
            _ship = ship;
            _camera = Camera.main;
        }

        public bool ShouldReturn(Transform bullet)
        {
            var shouldReturn = false;
            
            if ((bullet.position - _ship.ShipTransform.position).sqrMagnitude < 0.05f)
            {
                shouldReturn = true;
            }
            else
            {
                var vec = _camera.WorldToViewportPoint(bullet.position);
                if (vec.x < 0 || vec.x > 1 || vec.y < 0 || vec.y > 1)
                {
                    shouldReturn = true;
                }
            }

            return shouldReturn;
        }
    }
}