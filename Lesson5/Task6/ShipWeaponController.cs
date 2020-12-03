using TMPro;
using UnityEngine;

namespace Asteroids
{
    public class ShipWeaponController : IExecute
    {
        private readonly IShip _ship;
        private IExecute _bulletManager;
        private UpTimer _upTimer;
        private ShipWeaponLocker _weaponLocker;
        
        public ShipWeaponController(IShip ship, Transform bullet, Transform barrel, float bulletSpeed)
        {
            _upTimer = new UpTimer(0.0f, 3.0f);
            _weaponLocker = new ShipWeaponLocker(false);
            _bulletManager = new BulletManager(bullet, barrel, bulletSpeed, _weaponLocker);
            ship.ShipAction += ShouldContinueShooting;
        }

        public void Execute(float deltaTime)
        {
            if (_weaponLocker.IsLocked)
            {
                _upTimer.UpTimerTick(deltaTime);
                if (Mathf.Approximately(_upTimer.CurrentValue, _upTimer.MAXValue))
                {
                    _weaponLocker.IsLocked = false;
                }
            }
            _bulletManager.Execute(deltaTime);
        }

        private void ShouldContinueShooting(Transform transform)
        {
            _weaponLocker.IsLocked = true;
        }
    }
}