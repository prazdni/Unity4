using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface ISimpleEnemy
    {
        Transform Transform { get; }
        
        Health Health { get; }

        List<Vector3> Waypoints { get; }
        
        float Speed { get; }
        
        float Damage { get; set; }
    }
}