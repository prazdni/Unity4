using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MovementInput : IExecute
    {
        private IMoveViewModel _movePlayer;
        private IRotationViewModel _rotationPlayer;
        private IUserAxisInput _horizontal;
        private IUserAxisInput _vertical;
        private Vector3 _direction;
        
        
        
        public MovementInput(ICharacterModel character)
        {
            _horizontal = new PCUserAxisInputHorizontal();
            _vertical = new PCUserAxisInputVertical();
            
            _movePlayer = new MoveViewModel(character);
            _rotationPlayer = new RotationViewModel(character);
            
            _direction = Vector3.zero;
        }


        public void Execute(float deltaTime)
        {
            _direction = GetCurrentDirection(_direction);
            
            if (_direction.magnitude != 0)
            {
                _movePlayer.Move(_direction, deltaTime);

                _rotationPlayer.Rotate(_direction, deltaTime);
            }
        }

        private Vector3 GetCurrentDirection(Vector3 direction)
        {
            direction.Set(_horizontal.GetAxis(), 0, _vertical.GetAxis());
            direction = direction.normalized;
            return direction;
        }
    }
}