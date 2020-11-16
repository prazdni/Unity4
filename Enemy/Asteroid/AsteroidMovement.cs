using UnityEngine;

namespace Asteroids
{
    public class AsteroidMovement : IExecute
    {
        private IEnemy _enemy;
        private Vector3 _moveVector;
        
        public AsteroidMovement(IEnemy enemy, float currentSpeed)
        {
            _enemy = enemy;
            _moveVector = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized) *
                          currentSpeed;
        }

        public void Execute(float deltaTime)
        {
            var moveVector = _moveVector * deltaTime;

            _enemy.SceneEnemy.position += moveVector;
        }
    }
}