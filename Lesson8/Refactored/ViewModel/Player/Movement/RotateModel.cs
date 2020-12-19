using UnityEngine;

namespace Unity4.Lesson8
{
    public class RotateModel : IRotation
    {
        private ICharacterModel _character;
        private float _rotationSpeed;

        public RotateModel(ICharacterModel character)
        {
            _character = character;
            _rotationSpeed = character.SpeedModel.RotationSpeed;
        }
        
        public void Rotate(Vector3 direction, float deltaTime)
        {
            Vector3 desiredForward = Vector3.RotateTowards(_character.Transform.forward, direction,
                _rotationSpeed * deltaTime, 0.0f);
            
            _character.Transform.rotation = Quaternion.LookRotation(desiredForward);
        }
    }
}