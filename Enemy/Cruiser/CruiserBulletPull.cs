using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class CruiserBulletPull
    {
        private int _bulletCapacity;
        private List<Transform> _bullets;
        private IFactory _bulletFactory;
        
        public CruiserBulletPull(int bulletCapacity, Transform bullet)
        {
            _bulletFactory = new BulletFactory(bullet);
            
            _bulletCapacity = bulletCapacity;
            _bullets = new List<Transform>();
            
            CreateBullets();
        }

        public Transform GetBullet()
        {
            var bullet = _bullets.FirstOrDefault(b => !b.gameObject.activeSelf);

            if (bullet == null)
            {
                CreateBullets();
                bullet = _bullets.FirstOrDefault(b => !b.gameObject.activeSelf);
            }
            
            bullet.gameObject.SetActive(true);

            return bullet;
        }

        private void CreateBullets()
        {
            for (int i = 0; i < _bulletCapacity; i++)
            {
                _bullets.Add(_bulletFactory.CreateInvisibleBullet());
            }
        }
        
        public void ReturnBullet(Transform bullet)
        {
            bullet.gameObject.SetActive(false);
        }
    }
}