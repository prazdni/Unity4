using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData", order = 2)]
    public abstract class EnemyData : ScriptableObject
    {
        [SerializeField] private Transform _enemyPrefab;
        [SerializeField] private EnemyType _typeOfEnemy;
        [SerializeField] private Health _enemyHealth;
        [SerializeField] private float _enemySpeed;

        public Transform EnemyPrefab => _enemyPrefab;

        public EnemyType TypeOfEnemy => _typeOfEnemy;

        public Health EnemyHealth => _enemyHealth;

        public float EnemySpeed => _enemySpeed;
    }
}