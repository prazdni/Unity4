using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IExplosionViewModel<T>
    {
        event Action<Vector3> OnCollision;
        
        T DamageObj { get; }

        void SetDamageOnCollision(Vector3 position);
    }
}