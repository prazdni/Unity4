using UnityEngine;

namespace Unity4.Lesson8
{
    public class MoveViewModel : IMoveViewModel
    {
        private CharacterModel _character;
        private float _speed;

        public MoveViewModel(CharacterModel character)
        {
            _character = character;
            _speed = character.SpeedModel.MoveSpeed;
        }

        public void Move(Vector3 direction, float deltaTime)
        {
            _character.Transform.position += direction * _speed * deltaTime;
        }
    }
}