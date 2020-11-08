using UnityEngine;

namespace Asteroids
{
    public class CruiserGunManager : IExecute
    {
        private Transform _enemy;
        private Timer _timer;
        private CruiserBulletPull _bulletPull;
        
        public CruiserGunManager(Transform enemy, Transform bullet)
        {
            _enemy = enemy;
            _bulletPull = new CruiserBulletPull(2, bullet);
            _timer = new Timer();
        }

        public void Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}