using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class SimpleEnemyModel : ISimpleEnemy
    {
        public Transform Transform { get; }
        
        public HealthModel HealthModel { get; }

        public List<Vector3> Waypoints { get; }
        
        public float Speed { get; }
        
        public float Damage { get; set; }

        public SimpleEnemyModel(Transform transform, HealthModel healthModel, List<Vector3> waypoints, float speed,
            float damage)
        {
            Transform = transform;
            HealthModel = healthModel;
            Waypoints = waypoints;
            Speed = speed;
            Damage = damage;
        }
    }
}