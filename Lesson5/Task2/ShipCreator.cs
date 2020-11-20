using UnityEngine;

namespace Asteroids
{
    public class ShipCreator
    {
        private Transform _sceneShipTransform;
        private Transform _sceneBarrel;
        private IShip _ship;

        public ShipCreator(ShipData shipData)
        {
            _sceneShipTransform = Object.Instantiate(shipData.Ship);
            
            var moveTransform = new AccelerationMove(_sceneShipTransform, shipData.ShipSpeed, shipData.ShipAcceleration);
            var rotation = new RotateShip(_sceneShipTransform);
            
            //_ship = new Ship(moveTransform, rotation, _sceneShipTransform);
            _ship = new Ship(new MouseMove(_sceneShipTransform, shipData.ShipSpeed),
                new AbsenceRotation(_sceneShipTransform), _sceneShipTransform);
            
            _sceneBarrel = Object.Instantiate(shipData.Barrel, _sceneShipTransform);
        }

        public IShip GetShip()
        {
            return _ship;
        }

        public Transform GetBarrel()
        {
            return _sceneBarrel;
        }
    }
}