using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyCollisionView : MonoBehaviour, IInitialize<IEnemyViewModel>
    {
        private IEnemyViewModel _enemyViewModel;
        
        public void Initialize(IEnemyViewModel viewModel)
        {
            _enemyViewModel = viewModel;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Explosion"))
            {
                _enemyViewModel.HurtEnemy(other.gameObject.GetComponent<IExplosionViewModel>().DamageObj);
            }
        }
    }
}