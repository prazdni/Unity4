using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity4.Lesson8
{
    public class HealthView : MonoBehaviour, IInitialize<IOnPlayerEffect<float>>
    {
        private float _healthBar;
        private Image _healthBarImage;
        
        private void Start()
        {
            _healthBarImage = GetComponent<Image>();
            _healthBar = _healthBarImage.fillAmount;
        }

        public void Initialize(IOnPlayerEffect<float> viewModel)
        {
            viewModel.OnEffect += ChangeHealthBar;
        }

        private void ChangeHealthBar(float health)
        {
            _healthBar += health;
            _healthBarImage.fillAmount = _healthBar;
        }
    }
}