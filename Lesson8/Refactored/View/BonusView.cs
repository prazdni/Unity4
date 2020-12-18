using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity4.Lesson8
{
    public class BonusView : MonoBehaviour, IInitialize<IOnPlayerEffect<IBonusModel>>
    {
        private Image _image;
        
        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void Initialize(IOnPlayerEffect<IBonusModel> bonusViewModel)
        {
            bonusViewModel.OnEffect += ShowBonus;
        }

        private void Update()
        {
            if (!Mathf.Approximately(_image.fillAmount, 0.0f))
            {
                _image.fillAmount -= Time.deltaTime;
            }
            else
            {
                _image.fillAmount = 0.0f;
            }
        }

        private void ShowBonus(IBonusModel bonus)
        {
            switch (bonus.EffectType)
            {
                case EffectType.None:
                    _image.fillAmount = 0.0f;
                    break;
                case EffectType.Speed:
                    _image.fillAmount = 1.0f;
                    break;
                case EffectType.Health:
                    _image.fillAmount = 1.0f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}