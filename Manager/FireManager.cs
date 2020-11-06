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

        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;

        public FireManager(Rigidbody2D bullet, Transform barrel, float force)
        {
            _fire = new PCUserInputFire();
            _bulletManager = new BulletManager();
            
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }
        
        public void Execute(float deltaTime)
        {
            if (_fire.IsKeyDown())
            {
                _bulletManager.Shoot(_bullet, _barrel, _force);
            }

            _bulletManager.QuantityOfBulletsCheck(deltaTime);
        }
    }
}