using UnityEngine;

namespace Asteroids
{
    public class BulletFactory : IFactory
    {
        private Transform _bulletTransform;

        public BulletFactory(Transform bullet)
        {
            _bulletTransform = bullet;
        }

        public Transform CreateInvisibleBullet()
        {
            var bullet = Object.Instantiate(_bulletTransform);
            bullet.gameObject.SetActive(false);
            return bullet;
        }
    }
}