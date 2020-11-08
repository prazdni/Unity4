using UnityEngine;

namespace Asteroids
{
    public class PositionSetter
    {
        private IShip _ship;
        private Camera _camera;
        
        public PositionSetter(IShip ship)
        {
            _ship = ship;
            _camera = Camera.main;
        }

        public void SetPosition(Transform transform)
        {
            var vec = _camera.ScreenToWorldPoint(Vector3.zero);
            transform.position.Set(vec.x, vec.y, vec.z);
        }
    }
}