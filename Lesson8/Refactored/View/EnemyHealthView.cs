using System;
using TMPro;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyView : MonoBehaviour, IInitialize<IEnemyHurtViewModel>
    {
        private TMP_Text _text;
        
        private void Start()
        {
            _text = GetComponentInChildren<TMP_Text>();
        }

        public void Initialize(IEnemyHurtViewModel viewModel)
        {
            _text = viewModel.
            viewModel.OnEnemyDamage += ChangeHealth;
        }

        private void ChangeHealth(float damage)
        {
            
        }
    }
}