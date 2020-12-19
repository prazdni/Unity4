using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Unity4.Lesson8
{
    public class EnemyViewModel : IEnemyViewModel
    {
        public float CurrentHealth => _enemyModel.HealthModel.CurrentHealth;
        public event Action<float> OnEnemyHurt = f => { };
        
        private ISimpleEnemyModel _enemyModel;
        private IExecute _moveEnemy;

        public EnemyViewModel(ISimpleEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _moveEnemy = new MoveEnemy(enemyModel.Waypoints, enemyModel.Transform.GetOrAddComponent<NavMeshAgent>());
        }

        public void HurtEnemy(float damage)
        {
            _enemyModel.HealthModel.CurrentHealth -= damage;

            DeathCheck();

            OnEnemyHurt.Invoke(damage);
        }

        public void Execute(float deltaTime)
        {
            _moveEnemy.Execute(deltaTime);
        }

        private void DeathCheck()
        {
            if (_enemyModel.HealthModel.CurrentHealth < 0)
            {
                _enemyModel.Transform.gameObject.SetActive(false);
            }
        }
    }
}