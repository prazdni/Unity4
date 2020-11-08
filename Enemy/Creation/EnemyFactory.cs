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
        
        public Enemy CreateEnemy(EnemyData enemyData)
        {
            switch (enemyData.TypeOfEnemy)
            {
                case EnemyType.None:
                    throw new ArgumentException("Missing enemy type");
                case EnemyType.Asteroid:
                    return new Asteroid(Object.Instantiate(enemyData.EnemyPrefab), enemyData as AsteroidData, _ship);
                case EnemyType.Cruiser:
                    return new Cruiser(Object.Instantiate(enemyData.EnemyPrefab), enemyData as CruiserData, _ship);
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyData.TypeOfEnemy), enemyData.TypeOfEnemy, null);
            }
        }
    }
}