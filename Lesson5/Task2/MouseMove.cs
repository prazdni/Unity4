using UnityEngine;

namespace Asteroids
{
    public class MouseMove : IMove
    {
        public float Speed { get; }

        private Camera _camera;
        private Transform _ship;

        public MouseMove(Transform transform, float speed)
        {
            _camera = Camera.main;
            _ship = transform;
            Speed = speed;
        }
        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            //var dir = Input.mousePosition - _camera.WorldToScreenPoint(_ship.position);
            var dir = (_camera.ScreenToWorldPoint(Input.mousePosition) - _camera.ScreenToWorldPoint(_ship.position)).normalized;
            
            if (dir.magnitude >= 0.5f)
            {
                _ship.position += dir * (Speed * deltaTime);
            }
        }
    }
}