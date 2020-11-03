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
        private ShipCreator _shipCreator;
        
        private InputController _inputController;
        private Ship _ship;

        private void Start()
        {
            _shipCreator = new ShipCreator(_shipData);

            _inputController = new InputController(_shipCreator.GetShip(), _shipData.Bullet, _shipCreator.GetBarrel(),
                _shipData.BulletForce);
        }

        private void Update()
        {
            _inputController.Execute(Time.deltaTime);
        }
    }
}

