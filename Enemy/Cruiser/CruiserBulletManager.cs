using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class CruiserBulletManager : IExecute
    {
        private ReturnChecker _returnChecker;
        private IEnemy _enemy;
        private CruiserBulletPull _bulletPull;
        private float _bulletSpeed;

        private List<Transform> _bullets;
        private UpTimer _upTimer;
        
        public CruiserBulletManager(IEnemy enemy, Transform bullet, IShip ship, float bulletSpeed)
        {
            _bulletSpeed = bulletSpeed;
            _enemy = enemy;
            _upTimer = new UpTimer(0.0f, 0.5f);
            _returnChecker = new ReturnChecker(ship);
            _bulletPull = new CruiserBulletPull(2, bullet);
            _bullets = new List<Transform>();
        }

        public void Execute(float deltaTime)
        {
            if (_upTimer.MAXValue < _upTimer.CurrentValue)
            {
                AddBulletToList(_bulletPull.GetBullet());
                
                _upTimer.ResetTimer();
            }
            else
            {
                for (int i = 0; i < _bullets.Count; i++)
                {
                    var bullet = _bullets[i];
                    bullet.position += Vector3.up * (_bulletSpeed * deltaTime);
                    
                    if (_returnChecker.ShouldReturn(bullet))
                    {
                        _bulletPull.ReturnBullet(bullet);
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
    }
}