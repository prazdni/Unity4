﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class EnemyPool
    {
        private EnemyFactory _enemyFactory;

        private List<IEnemy> _enemies;
        private EnemyData[] _enemyData;
        
        public EnemyPool(IShip ship, params EnemyData[] data)
        {
            _enemyFactory = new EnemyFactory(ship);
            _enemies = new List<IEnemy>();
            _enemyData = new EnemyData[data.Length];
            CopyEnemyData(data);
            CreateEnemies();
        }

        public IEnemy GetEnemy()
        {
            var enemy = _enemies.FirstOrDefault(e => !e.SceneEnemy.gameObject.activeSelf);

            if (enemy == null)
            {
                CreateEnemies();
                enemy = _enemies.FirstOrDefault(e => !e.SceneEnemy.gameObject.activeSelf);
            }

            return enemy;
        }

        public void ReturnEnemy(Transform enemyTransform)
        {
            enemyTransform.gameObject.SetActive(false);
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < _enemyData.Length; i++)
            {
                var enemy = _enemyFactory.CreateHiddenEnemy(_enemyData[i]);
                _enemies.Add(enemy);
            }
        }

        private void CopyEnemyData(EnemyData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _enemyData[i] = data[i];
            }
        }
    }
}