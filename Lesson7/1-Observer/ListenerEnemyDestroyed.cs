using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class ListenerEnemyDestroyed
    {
        private IEnemy _enemy;

        private List<EnemyInfoUI> _behaviours;
        
        public ListenerEnemyDestroyed()
        {
            _behaviours = Object.FindObjectsOfType<EnemyInfoUI>().ToList();
        }

        public void AddEnemyListeners(IEnemy enemy)
        {
            for (int i = 0; i < _behaviours.Count; i++)
            {
                enemy.EnemyAction += _behaviours[i].ShowInfo;
            }
        }
        
        public void RemoveEnemyListeners(IEnemy enemy)
        {
            for (int i = 0; i < _behaviours.Count; i++)
            {
                enemy.EnemyAction += _behaviours[i].ShowInfo;
            }
        }
    }
}