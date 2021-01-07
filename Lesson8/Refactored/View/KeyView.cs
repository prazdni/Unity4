using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity4.Lesson8
{
    public class KeyView : MonoBehaviour, IInitialize<IKeyViewModel>
    {
        private RectTransform[] _endGameObjects;
        
        private void Start()
        {
            _endGameObjects = GetComponentsInChildren<RectTransform>();
            
            for (int i = 0; i < _endGameObjects.Length; i++)
            {
                _endGameObjects[i].gameObject.SetActive(false);
            }
        }

        public void Initialize(IKeyViewModel viewModel)
        {
            viewModel.OnKeyTake += OnKeyTaken;
        }

        private void OnKeyTaken()
        {
            Time.timeScale = 0.0f;
            
            for (int i = 0; i < _endGameObjects.Length; i++)
            {
                _endGameObjects[i].gameObject.SetActive(true);
            }
        }
    }
}