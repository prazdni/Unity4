using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyManager : IExecute
    {
        private List<IEnemy> _enemies;
        private Timer _timer;
        private EnemyPool _enemyPool;
        private ReturnChecker _returnChecker;
        private PositionSetter _positionSetter;
        
        public EnemyManager(IShip ship, params EnemyData[] enemies)
        {
            _enemyPool = new EnemyPool(ship, enemies);
            _enemies = new List<IEnemy>();
            _returnChecker = new ReturnChecker(ship);
            _positionSetter = new PositionSetter(ship);
            
            AddEnemies(enemies.Length);
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].SceneEnemy.gameObject.activeSelf)
                {
                    if (_returnChecker.ShouldReturn(_enemies[i]))
                    {
                        _enemyPool.ReturnEnemy(_enemies[i].SceneEnemy);
                    }
                    else
                    {
                        _enemies[i].Execute(deltaTime);
                    }
                }
            }
        }

        private void AddEnemies(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                var enemy = _enemyPool.GetEnemy();
                enemy.SceneEnemy.gameObject.SetActive(true);
                _enemies.Add(enemy);
            }
        }
    }
}