using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Unity4.Lesson8
{
    public class EndGameChecker : MonoBehaviour, IInitialize<IOnPlayerEffect<float>>
    {
        private float _damageTaken;
        private RectTransform[] _endGameObjects;
        
        private void Start()
        {
            _endGameObjects = GetComponentsInChildren<RectTransform>();
            
            for (int i = 0; i < _endGameObjects.Length; i++)
            {
                _endGameObjects[i].gameObject.SetActive(false);
            }
            
            _damageTaken = 0.0f;
        }

        public void Initialize(IOnPlayerEffect<float> viewModel)
        {
            viewModel.OnEffect += OnEffect;
        }

        private void OnEffect(float effect)
        {
            _damageTaken -= effect;

            if (_damageTaken >= 1)
            {
                Time.timeScale = 0.0f;
                
                for (int i = 0; i < _endGameObjects.Length; i++)
                {
                    _endGameObjects[i].gameObject.SetActive(true);
                }
            }
        }
    }
}