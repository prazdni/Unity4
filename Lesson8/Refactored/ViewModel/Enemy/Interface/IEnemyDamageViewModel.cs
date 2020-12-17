using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IEnemyDamageViewModel
    {
        Transform Transform { get; }
        event Action<float> OnEnemyDamage;
        void DamageEnemy(float damage);
    }
}