using System.Collections.Generic;
using Unity4.Lesson6;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Asteroids
{
    public class EnemyManager : IExecute
    {
        private IShip _ship;
        private List<IEnemy> _enemies;
        private IPullable<IEnemy> _enemyPool;
        private TransformReturnChecker _transformReturnChecker;
        private ShipCollisionChecker _shipCollisionChecker;
        private PositionSetter _positionSetter;
        private MessageBroker _messageBroker;
        
        public EnemyManager(IShip ship, params EnemyData[] enemies)
        {
            _ship = ship;
            _enemyPool = new EnemyPool(ship, enemies);
            _enemies = new List<IEnemy>();
            _transformReturnChecker = new TransformReturnChecker();
            _shipCollisionChecker = new ShipCollisionChecker(ship);
            _positionSetter = new PositionSetter(ship);
            _messageBroker = new MessageBroker();
            
            AddEnemies(enemies.Length);
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].SceneEnemy.gameObject.activeSelf)
                {

                    if (_transformReturnChecker.ShouldReturn(_enemies[i].SceneEnemy))
                    {
                        _enemies[i].OnAction(new EnemyEventInfo(_ship.ShipTransform, false));
                        OnReturnToPool(_enemies[i]);
                    }
                    else if (_shipCollisionChecker.IsCollision(_enemies[i].SceneEnemy))
                    {
                        _enemies[i].OnAction(new EnemyEventInfo(_ship.ShipTransform, true));
                        OnReturnToPool(_enemies[i]);
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

        private void OnReturnToPool(IEnemy enemy)
        {
            _enemyPool.Return(enemy);
            _messageBroker.OnDestroyObject(enemy.SceneEnemy);
        }
    }
}