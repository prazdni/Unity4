﻿using UnityEngine;

namespace Unity4.Lesson8
{
    public class RotationViewModel : IRotationViewModel
    {
        private CharacterModel _character;
        private float _rotationSpeed;

        public RotationViewModel(CharacterModel character)
        {
            _character = character;
            _rotationSpeed = character.Speed.RotationSpeed;
        }
        
        public void Rotate(Vector3 direction, float deltaTime)
        {
            Vector3 desiredForward = Vector3.RotateTowards(_character.Transform.forward, direction,
                _rotationSpeed * deltaTime, 0.0f);
            
            _character.Transform.rotation = Quaternion.LookRotation(desiredForward);
        }
    }
}