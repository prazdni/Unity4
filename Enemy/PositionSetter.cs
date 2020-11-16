using UnityEngine;

namespace Asteroids
{
    public class PositionSetter
    {
        private IShip _ship;
        
        public PositionSetter(IShip ship)
        {
            _ship = ship;
        }

        public void SetPosition(Transform transform)
        {
            transform.position = _ship.ShipTransform.position - Vector3.up * 2;
        }
    }
}