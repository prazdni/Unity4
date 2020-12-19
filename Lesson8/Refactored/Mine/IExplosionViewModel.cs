using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IExplosionViewModel
    {
        event Action<Vector3> OnCollision;
        
        float DamageObj { get; }

        void Explode(Vector3 position);
    }
}