using Asteroids;
using UnityEngine;

namespace Manager
{
    public class RotationManager : IExecute
    {
        private Camera _camera;
        private IShip _ship;
        
        public RotationManager(IShip ship, Camera camera)
        {
            _camera = Camera.main;
            _ship = ship;
        }
        
        public void Execute(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_ship.ShipTransform.position);
            
            _ship.Rotation(direction);
        }
    }
}