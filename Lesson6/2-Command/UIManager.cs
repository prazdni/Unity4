using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class UIManager : IExecute
    {
        private IUserKeyInput _escapeButton;
        private List<BaseUI> _allBaseUI;
        private BaseUI _currentWindow;

        public UIManager()
        {
            _escapeButton = new PCUserInputEscape();
            _allBaseUI = Object.FindObjectsOfType<BaseUI>().ToList();
            for (int i = 0; i < _allBaseUI.Count; i++)
            {
                _allBaseUI[i].gameObject.SetActive(false);
            }
        }

        public void Execute(float deltaTime)
        {
            if (_escapeButton.IsKeyDown())
            {
                var menu = _allBaseUI.Find(a => a is MenuInterface);
                
                if (!menu.gameObject.activeSelf)
                {
                    menu.ExecuteUI();
                }
                else
                {
                    menu.HideUI();
                }
            }
        }
    }
}