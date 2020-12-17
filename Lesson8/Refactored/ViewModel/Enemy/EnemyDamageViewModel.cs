using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyDamageViewModel : IEnemyDamageViewModel
    {
        public Transform Transform { get; }
        public event Action<float> OnEnemyDamage = f => { };
        
        private ISimpleEnemy _enemy;
        
        public EnemyDamageViewModel(ISimpleEnemy enemy)
        {
            _enemy = enemy;
        }

        public void DamageEnemy(float damage)
        {
            _enemy.Health.CurrentHealth -= damage;
            OnEnemyDamage.Invoke(_enemy.Health.CurrentHealth);
        }
    }
}