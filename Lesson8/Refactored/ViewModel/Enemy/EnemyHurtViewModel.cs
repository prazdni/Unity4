using System;

namespace Unity4.Lesson8
{
    public class EnemyHurtViewModel : IEnemyHurtViewModel
    {
        public event Action<float> OnEnemyHurt = f => { };
        private IHealth _enemyHealth;
        
        public EnemyHurtViewModel(IHealth enemyHealth)
        {
            _enemyHealth = enemyHealth;
            OnEnemyHurt += Hurt;
        }

        private void Hurt(float damage)
        {
            _enemyHealth.CurrentHealth -= damage;
        }
    }
}