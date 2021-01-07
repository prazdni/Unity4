using System;
using TMPro;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class EnemyHealthView : MonoBehaviour, IInitialize<IEnemyViewModel>
    {
        private TMP_Text _text;
        
        private void Start()
        {
            _text = GetComponentInChildren<TMP_Text>();
            
        }

        public void Initialize(IEnemyViewModel viewModel)
        {
            viewModel.OnEnemyHurt += ChangeHealth;
            _text.text = (viewModel.CurrentHealth).ToString();
        }

        private void ChangeHealth(float damage)
        {
            _text.text = (Convert.ToDouble(_text.text) - damage).ToString();
        }
    }
}