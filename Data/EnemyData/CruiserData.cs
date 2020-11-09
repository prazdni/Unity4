using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "CruiserData", menuName = "Enemy/CruiserData", order = 2)]
    public class CruiserData : EnemyData
    {
        [SerializeField] private Transform _bullet;

        public Transform Bullet => _bullet;
    }
}