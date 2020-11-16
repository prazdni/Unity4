using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "BaseShip", menuName = "Ship/BaseShip", order = 0)]
    public class ShipData : ScriptableObject
    {
        [SerializeField] private Transform _playerShip;
        [SerializeField] private float _speed;
        [SerializeField] private float shipAcceleration;
        [SerializeField] private Transform _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _bulletForce;

        public Transform Ship => _playerShip;
        public float ShipSpeed => _speed;
        public float ShipAcceleration => shipAcceleration;
        public Transform Bullet => _bullet;
        public float BulletForce => _bulletForce;
        public Transform Barrel => _barrel;
    }
}