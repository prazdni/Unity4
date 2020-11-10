using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class CruiserBulletManager : IExecute
    {
        private IReturnable _returnChecker;
        private IEnemy _enemy;
        private IPullable<Transform> _bulletPull;
        private float _bulletSpeed;

        private List<Transform> _bullets;
        private UpTimer _upTimer;
        
        public CruiserBulletManager(IEnemy enemy, Transform bullet, IShip ship, float bulletSpeed)
        {
            _bulletSpeed = bulletSpeed;
            _enemy = enemy;
            _upTimer = new UpTimer(0.0f, 0.5f);
            _returnChecker = new TransformCollisionAndReturnChecker(ship);
            _bulletPull = new BulletPull(bullet);
            _bullets = new List<Transform>();
        }

        public void Execute(float deltaTime)
        {
            if (_upTimer.MAXValue < _upTimer.CurrentValue)
            {
                AddBulletToList(_bulletPull.Get());
                
                _upTimer.ResetTimer();
            }
            else
            {
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

            _upTimer.UpTimerTick(deltaTime);
        }

        private void AddBulletToList(Transform bullet)
        {
            bullet.transform.position = _enemy.SceneEnemy.position;
            bullet.rotation = _enemy.SceneEnemy.rotation;
                    
            _bullets.Add(bullet);
        }

        private void MoveBullet(Transform bullet, float deltaTime)
        {
            bullet.position += bullet.up * (_bulletSpeed * deltaTime);
        }
    }
}