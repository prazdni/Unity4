using UnityEngine;

namespace Unity4.Lesson8
{
    public class MoveModel : IMove
    {
        private ICharacterModel _character;
        private float _speed;

        public MoveModel(ICharacterModel character)
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