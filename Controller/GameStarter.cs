using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private ShipData _shipData;
        [SerializeField] private AsteroidData _asteroidData;
        [SerializeField] private CruiserData _cruiserData;
        
        private ShipCreator _shipCreator;
        private EnemyPool _enemyPool;

        private EnemyManager _enemyManager;
        private InputController _inputController;
        private Ship _ship;

        private void Start()
        {
            _shipCreator = new ShipCreator(_shipData);
            
            _enemyManager = new EnemyManager(_shipCreator.GetShip(),_asteroidData, _cruiserData);

            _inputController = new InputController(_shipCreator.GetShip(), _shipData.Bullet, _shipCreator.GetBarrel(),
                _shipData.BulletForce);
        }

        private void Update()
        {
            _inputController.Execute(Time.deltaTime);
            _enemyManager.Execute(Time.deltaTime);
        }
    }
}

