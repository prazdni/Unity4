using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IEnemyHurtViewModel
    {
        Transform Transform { get; }
        float CurrentHealth { get; }
        event Action<float> OnEnemyHurt;
        void HurtEnemy(float damage);
    }
}