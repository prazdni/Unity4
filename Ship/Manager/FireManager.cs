using System;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class FireManager : IExecute
    {
        private IUserKeyInput _fire;
        private BulletManager _bulletManager;
        
        private float _force;

        public FireManager(Transform bullet, Transform barrel, float force)
        {
            _fire = new PCUserInputFire();
            //_bulletManager = new BulletManager(bullet, barrel);

            _force = force;
        }
        
        public void Execute(float deltaTime)
        {
            if (_fire.IsKeyDown())
            {
            //    _bulletManager.Shoot(_force);
            }

            //_bulletManager.QuantityOfBulletsCheck(deltaTime);
        }
    }
}