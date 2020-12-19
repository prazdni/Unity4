using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeInput : IExecute
    {
        private IUserKeyInput _grenadeInput;
        private IGrenadeThrow _grenadeThrow;

        public GrenadeInput(IPull<IGrenadeModel> grenades, Transform throwGrenadePosition,
            ITakeObject takeObject)
        {
            _grenadeThrow = new GrenadeThrow(grenades, throwGrenadePosition, takeObject);
            _grenadeInput = new PCUserInputGrenade();
        }
        
        public void Execute(float deltaTime)
        {
            if (_grenadeInput.IsKeyUp())
            {
                _grenadeThrow.Throw();
            }
            
            _grenadeThrow.Execute(deltaTime);
        }
    }
}