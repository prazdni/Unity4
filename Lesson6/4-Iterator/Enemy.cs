using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : IEnemy, IExecute
    {
        private List<EnemyAbility> _abilities;
        private Transform _rootPool;
        protected Speed _speed;
        private IShip _ship;
        private ShipCollisionChecker _shipCollisionChecker;

        public Transform SceneEnemy { get; }
        public Action<Transform> OnAction { get; }

        public EnemyAbility this[AbilityState state]
        {
            get
            {
                switch (state)
                {
                    case AbilityState.NONE:
                        return _abilities.Find(a => a is DoNothingAbility);
                    case AbilityState.CHANGEBUTTONS:
                        return _abilities.Find(a => a is ChangeButtonsAbility);
                    case AbilityState.PARALYZE:
                        return _abilities.Find(a => a is ParalyzeAbility);
                    case AbilityState.SLOWDOWN:
                        return _abilities.Find(a => a is SlowDownAbility);
                    default:
                        return _abilities.Find(a => a is DoNothingAbility);
                }
            }
        }
        
        public Enemy(Transform sceneEnemy, EnemyData enemyData, IShip ship, List<EnemyAbility> abilities)
        {
            _ship = ship;
            
            SceneEnemy = sceneEnemy;
            
            _speed = new Speed(enemyData.EnemySpeed);
            
            _shipCollisionChecker = new ShipCollisionChecker(ship);

            _abilities = abilities;

            OnAction += OnTransformAction;
        }

        public virtual void Execute(float deltaTime)
        {
        }

        private void OnTransformAction(Transform transform)
        {
            Debug.Log("Enemy Interacted!");
        }

        public IEnumerable<EnemyAbility> GetAbility()
        {
            return _abilities;
        }
    }
}