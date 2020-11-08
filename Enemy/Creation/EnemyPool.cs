using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyCreator
    {
        private EnemyFactory _enemyFactory;

        private List<Enemy> _enemies;

        public EnemyCreator(IShip ship, params EnemyData[] data)
        {
            _enemyFactory = new EnemyFactory(ship);
            
            _enemies = new List<Enemy>();

            for (int i = 0; i < data.Length; i++)
            {
                _enemies.Add(_enemyFactory.CreateEnemy(data[i]));
            }
        }

        public List<Enemy> GetEnemies()
        {
            return _enemies;
        }

        public Enemy GetRandomEnemy()
        {
            return _enemies[Random.Range(0, _enemies.Count)];
        }
    }
}