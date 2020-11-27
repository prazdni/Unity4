using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        private IExecute _asteroidMovement;
        
        public Asteroid(Transform sceneEnemy, AsteroidData asteroidData, IShip ship, List<EnemyAbility> abilities) : 
            base(sceneEnemy, asteroidData, ship, abilities)
        {
            _asteroidMovement = new AsteroidMovement(this, _speed.Current);
        }

        public override void Execute(float deltaTime)
        {
            base.Execute(deltaTime);
            _asteroidMovement.Execute(deltaTime);
        }
    }
}