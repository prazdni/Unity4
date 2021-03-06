﻿using System;
using System.Collections.Generic;
using Lesson5.Decorator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class BulletManager : IExecute
    {
        private IUserKeyInput _fire;
        private Transform _barrel;
        private IPullable<Transform> _bulletPull;
        private IReturnable _returnChecker;
        private List<Transform> _bullets;
        private float _bulletSpeed;
        private ShipWeaponLocker _weaponLocker;

        public BulletManager(Transform bullet, Transform barrel, float bulletSpeed, ShipWeaponLocker weaponLocker)
        {
            _barrel = barrel;
            _bulletSpeed = bulletSpeed;
            _fire = new PCUserInputFire();
            _bulletPull = new BulletPull(bullet);
            _returnChecker = new TransformReturnChecker();
            _bullets = new List<Transform>();
            _weaponLocker = weaponLocker;
        }

        public void Execute(float deltaTime)
        {
            if (!_weaponLocker.IsLocked)
            {
                if (_fire.IsKeyDown())
                {
                    AddBulletToList(_bulletPull.Get());
                }
            }

            for (int i = 0; i < _bullets.Count; i++)
            {
                var bullet = _bullets[i];
                    
                MoveBullet(bullet, deltaTime);
                    
                if (_returnChecker.ShouldReturn(bullet))
                {
                    _bulletPull.Return(bullet);
                }
            }

            _bullets.RemoveAll(b => !b.gameObject.activeSelf);
        }
        
        private void MoveBullet(Transform bullet, float deltaTime)
        {
            bullet.position += bullet.up * (_bulletSpeed * deltaTime);
        }
        
        private void AddBulletToList(Transform bullet)
        {
            bullet.transform.position = _barrel.position;
            bullet.rotation = _barrel.rotation;
                    
            _bullets.Add(bullet);
        }
    }
}