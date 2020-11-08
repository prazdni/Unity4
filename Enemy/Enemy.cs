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

        public Transform SceneEnemy { get; }
        public Action<Transform> OnAction { get; }

        protected Transform _sceneEnemy;

        public Enemy(Transform sceneEnemy, EnemyData enemyData)
        {
            SceneEnemy = sceneEnemy;

            _sceneEnemy = sceneEnemy;
            
            _speed = new Speed(10.0f);

            OnAction += OnTransformAction;
        }

        public abstract void Execute(float deltaTime);

        private void OnTransformAction(Transform transform)
        {
            Debug.Log("Enemy Interacted!");
        }
    }
}