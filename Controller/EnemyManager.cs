using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyManager : IExecute
    {
        private IShip _ship;
        private List<IEnemy> _enemies;
        private IPullable<IEnemy> _enemyPool;
        private TransformCollisionAndReturnChecker _transformCollisionAndReturnChecker;
        private PositionSetter _positionSetter;
        
        public EnemyManager(IShip ship, params EnemyData[] enemies)
        {
            _ship = ship;
            _enemyPool = new EnemyPool(ship, enemies);
            _enemies = new List<IEnemy>();
            _transformCollisionAndReturnChecker = new TransformCollisionAndReturnChecker(ship);
            _positionSetter = new PositionSetter(ship);
            
            AddEnemies(enemies.Length);
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].SceneEnemy.gameObject.activeSelf)
                {
                    if (_transformCollisionAndReturnChecker.ShouldReturn(_enemies[i].SceneEnemy))
                    {
                        _enemies[i].OnAction.Invoke(_ship.ShipTransform);
                        _enemyPool.Return(_enemies[i]);
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
                var enemy = _enemyPool.Get();
                enemy.SceneEnemy.gameObject.SetActive(true);
                _positionSetter.SetPosition(enemy.SceneEnemy);
                _enemies.Add(enemy);
            }
        }
    }
}