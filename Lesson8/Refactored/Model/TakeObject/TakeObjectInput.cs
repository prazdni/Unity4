using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class TakeObjectInput : IExecute
    {
        private IUserKeyInput _takeObjectInput;
        private ITakeObject _takeObject;
        
        public TakeObjectInput(ITakeObject takeObject)
        {
            _takeObjectInput = new PCUserInputTake();
            _takeObject = takeObject;
        }

        public void Execute(float deltaTime)
        {
            if (_takeObjectInput.IsKeyUp())
            {
                _takeObject.Take();
            }
            
            _takeObject.Execute(deltaTime);
        }
    }
}