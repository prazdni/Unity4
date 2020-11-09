using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        private IExecute _asteroidMovement;
        private CollisionChecker _collisionChecker;
        public Asteroid(Transform sceneEnemy, AsteroidData asteroidData, IShip ship) : 
            base(sceneEnemy, asteroidData)
        {
            _asteroidMovement = new AsteroidMovement(_sceneEnemy, _speed.Current);
        }

        public override void Execute(float deltaTime)
        {
            _asteroidMovement.Execute(deltaTime);
        }
    }
}