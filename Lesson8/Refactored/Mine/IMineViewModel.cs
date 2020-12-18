using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMineViewModel
    {
        event Action<Vector3> OnCollision;

        void SetDamageOnCollision(Vector3 position);
    }
}