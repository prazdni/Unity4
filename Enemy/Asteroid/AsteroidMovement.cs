using UnityEngine;

namespace Asteroids
{
    public class AsteroidMovement : IExecute
    {
        private Transform _sceneEnemy;
        private Vector3 _moveVector;
        
        public AsteroidMovement(Transform sceneEnemy, float currentSpeed)
        {
            _sceneEnemy = sceneEnemy;
            _moveVector = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized) *
                          currentSpeed;
        }

        public void Execute(float deltaTime)
        {
            var moveVector = _moveVector * deltaTime;

            _sceneEnemy.transform.position += moveVector;
        }
    }
}