using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMineViewModel
    {
        event Action<Vector3, float> OnCollision;
        float ExplosionForce  { get; }
        float ExplosionRadius { get; }

        void SetDamageOnCollision(Vector3 position);
    }
}