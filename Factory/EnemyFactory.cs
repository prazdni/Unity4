using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class EnemyFactory : IEnemyFactory
    {
        private IShip _ship;
        private List<EnemyAbility> _abilities;

        public EnemyFactory(IShip ship)
        {
            _ship = ship;
            
            _abilities = new List<EnemyAbility>
            {
                new ParalyzeAbility(),
                new SlowDownAbility(),
                new ChangeButtonsAbility(),
                new DoNothingAbility()
            };
        }
        
        public IEnemy CreateHiddenEnemy(EnemyData enemyData)
        {
            IEnemy enemy = null;
            
            switch (enemyData.TypeOfEnemy)
            {
                case EnemyType.None:
                    throw new ArgumentException("Missing enemy type");
                case EnemyType.Asteroid:
                    enemy = new Asteroid(Object.Instantiate(enemyData.EnemyPrefab), enemyData as AsteroidData, _ship, _abilities);
                    break;
                case EnemyType.Cruiser:
                    enemy = new Cruiser(Object.Instantiate(enemyData.EnemyPrefab), enemyData as CruiserData, _ship, _abilities);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyData.TypeOfEnemy), enemyData.TypeOfEnemy, null);
            }
            
            enemy.SceneEnemy.gameObject.SetActive(false);

            return enemy;
        }
    }
}