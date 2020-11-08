using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyController : IExecute
    {
        private List<Enemy> _enemies;
        private int _enemyCapacity;
        private IShip _ship;
        private Timer _timer;
        private EnemyManager _enemyManager;
        
        public EnemyController(int enemyCapacity, IShip ship, params EnemyData[] enemies)
        {
            _enemyCapacity = enemyCapacity;
            _enemyManager = new EnemyManager(ship, enemies);
            _ship = ship;
            _enemies = _enemyManager.GetEnemies();

        }

        public void Execute(float deltaTime)
        {
            bool allHidden = true;
            
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].SceneEnemy.gameObject.activeSelf)
                {
                    allHidden = false;
                    _enemies[i].Execute(deltaTime);
                }
            }

            if (allHidden)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    _enemies[i].SceneEnemy.gameObject.SetActive(true);
                }
                
                _enemies.Add(_enemyManager.GetRandomEnemy());
            }
        }
    }
}