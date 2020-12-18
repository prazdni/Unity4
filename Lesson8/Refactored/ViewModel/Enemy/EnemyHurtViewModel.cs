using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyHurtViewModel : IEnemyHurtViewModel
    {
        public Transform Transform { get; }
        public float CurrentHealth => _enemyModel.HealthModel.CurrentHealth;
        public event Action<float> OnEnemyHurt = f => { };
        
        private ISimpleEnemyModel _enemyModel;
        
        public EnemyHurtViewModel(ISimpleEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            Transform = _enemyModel.Transform;
        }

        public void HurtEnemy(float damage)
        {
            _enemyModel.HealthModel.CurrentHealth -= damage;
            OnEnemyHurt.Invoke(damage);
        }
    }
}