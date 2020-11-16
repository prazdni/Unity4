using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : IEnemy, IExecute
    {
        public static IEnemyFactory Factory;
        private Transform _rootPool;
        protected Speed _speed;
        private IShip _ship;
        private ShipCollisionChecker _shipCollisionChecker;

        public Transform SceneEnemy { get; }
        public Action<Transform> OnAction { get; }
        
        public Enemy(Transform sceneEnemy, EnemyData enemyData, IShip ship)
        {
            _ship = ship;
            
            SceneEnemy = sceneEnemy;
            
            _speed = new Speed(enemyData.EnemySpeed);
            
            _shipCollisionChecker = new ShipCollisionChecker(ship);

            OnAction += OnTransformAction;
        }

        public virtual void Execute(float deltaTime)
        {
        }

        private void OnTransformAction(Transform transform)
        {
            Debug.Log("Enemy Interacted!");
        }
    }
}