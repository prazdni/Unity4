using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids
{
    public class BulletPull : IPullable<Transform>
    {
        private List<Transform> _bullets;
        private IFactory _bulletFactory;
        
        public BulletPull(Transform bullet)
        {
            _bulletFactory = new BulletFactory(bullet);
            
            _bullets = new List<Transform>();
            
            CreateBullets();
        }

        public Transform Get()
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

        public void Return(Transform returnObject)
        {
            returnObject.gameObject.SetActive(false);
        }
        
        private void CreateBullets()
        {
            var bulletsCount = _bullets.Count;
            
            if (bulletsCount == 0)
            {
                bulletsCount++;
            }
            
            for (int i = 0; i < bulletsCount; i++)
            {
                _bullets.Add(_bulletFactory.CreateInvisibleItem());
            }
        }
    }
}