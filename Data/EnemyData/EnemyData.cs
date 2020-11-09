using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids
{
    public abstract class EnemyData : ScriptableObject
    {
        [SerializeField] private Transform _enemyPrefab;
        [SerializeField] private EnemyType _typeOfEnemy;
        [SerializeField] private Health _enemyHealth;

        public Transform EnemyPrefab => _enemyPrefab;

        public EnemyType TypeOfEnemy => _typeOfEnemy;

        public Health EnemyHealth => _enemyHealth;
    }
}