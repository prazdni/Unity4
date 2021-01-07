using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "ScriptableObjects/EnemyConfiguration", order = 0)]
    public class SimpleEnemyConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private List<Vector3> _wayPoints;
        [SerializeField] private HealthModel healthModel;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private int _quantity;

        public Transform Prefab => _prefab;

        public List<Vector3> WayPoints => _wayPoints;

        public HealthModel HealthModel => healthModel;

        public float Speed => _speed;

        public float Damage => _damage;

        public int Quantity => _quantity;
    }
}