using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class EnemyFactory : IEnemyFactory
    {
        private IShip _ship;
        
        public EnemyFactory(IShip ship)
        {
            _ship = ship;
        }
        
        public IEnemy CreateHiddenEnemy(EnemyData enemyData)
        {
            IEnemy enemy = null;
            
            switch (enemyData.TypeOfEnemy)
            {
                case EnemyType.None:
                    throw new ArgumentException("Missing enemy type");
                case EnemyType.Asteroid:
                    enemy = new Asteroid(Object.Instantiate(enemyData.EnemyPrefab), enemyData as AsteroidData, _ship);
                    break;
                case EnemyType.Cruiser:
                    enemy = new Cruiser(Object.Instantiate(enemyData.EnemyPrefab), enemyData as CruiserData, _ship);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyData.TypeOfEnemy), enemyData.TypeOfEnemy, null);
            }
            
            enemy.SceneEnemy.gameObject.SetActive(false);

            return enemy;
        }
    }
}