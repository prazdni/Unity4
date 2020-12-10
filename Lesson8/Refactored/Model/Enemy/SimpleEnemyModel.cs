using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class SimpleEnemyModel : ISimpleEnemy
    {
        public Transform Transform { get; }
        
        public Health Health { get; }

        public List<Vector3> Waypoints { get; }
        
        public float Speed { get; }
        
        public float Damage { get; set; }

        public SimpleEnemyModel(Transform transform, Health health, List<Vector3> waypoints, float speed,
            float damage)
        {
            Transform = transform;
            Health = health;
            Waypoints = waypoints;
            Speed = speed;
            Damage = damage;
        }
    }
}