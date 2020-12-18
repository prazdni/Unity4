using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyDamageViewModel : IEnemyDamageViewModel
    {
        public Transform Transform { get; }
        public event Action<float> OnEnemyDamage = f => { };
        
        private ISimpleEnemyModel _enemyModel;
        
        public EnemyDamageViewModel(ISimpleEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
        }

        public void DamageEnemy(float damage)
        {
            _enemyModel.HealthModel.CurrentHealth -= damage;
            OnEnemyDamage.Invoke(_enemyModel.HealthModel.CurrentHealth);
        }
    }
}