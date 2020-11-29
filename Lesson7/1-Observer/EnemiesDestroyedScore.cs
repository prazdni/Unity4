using System;
using TMPro;
using UnityEngine;

namespace Asteroids
{
    public class EnemiesDestroyedScore : ShowEnemyInfo
    {
        private TMP_Text _score;
        
        private void Start()
        {
            _score = GetComponent<TMP_Text>();
            _score.text = "0";
        }

        public override void ShowInfo(EnemyEventInfo info)
        {
            if (!info.IsOutOfBounds)
            {
                _score.text = (Convert.ToInt32(_score.text) + 1).ToString();
            }
        }
    }
}