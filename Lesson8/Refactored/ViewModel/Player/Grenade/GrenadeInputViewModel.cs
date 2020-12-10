using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeInputViewModel : IExecute
    {
        private GrenadeModel _grenade;
        private IUserKeyInput _grenadeInput;
        private IGrenadeThrower _grenadeThrower;
       
        
        public GrenadeInputViewModel(IGrenadeThrower grenadeThrower)
        {
            _grenadeThrower = grenadeThrower;
            _grenadeInput = new PCUserInputGrenade();
        }
        
        public void Execute(float deltaTime)
        {
            if (_grenadeInput.IsKeyUp())
            {
                _grenadeThrower.Throw();
            }
        }
    }
}