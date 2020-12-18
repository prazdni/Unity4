using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface ISimpleEnemyModel
    {
        Transform Transform { get; }
        
        HealthModel HealthModel { get; }

        List<Vector3> Waypoints { get; }
        
        float Speed { get; }
        
        float Damage { get; set; }
    }
}