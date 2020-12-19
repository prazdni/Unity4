using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrow : IGrenadeThrower
    {
        private IPull<IGrenadeModel> _grenades;
        private Transform _throwPoint;
        private ITakeObject _takeObject;
        private int _currentCount;

        public GrenadeThrow(IPull<IGrenadeModel> grenades, Transform throwPoint, ITakeObject takeObject)
        {
            _grenades = grenades;
            
            _throwPoint = throwPoint;
            
            _takeObject = takeObject;

            _currentCount = 0;
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                if (_currentCount < _grenades.Count )
                {
                    _currentCount++;
                    var grenade = _grenades.Get();
                    
                    if (grenade != null)
                    {
                        grenade.Transform.gameObject.SetActive(true);
                        SetPosition(grenade);
                        ThrowGrenade(grenade);
                    }
                    
                }
            }
        }

        private void SetPosition(IGrenadeModel grenade)
        {
            grenade.Transform.gameObject.SetActive(true);
            grenade.Transform.position = _throwPoint.position;
            grenade.Transform.rotation = _throwPoint.rotation;
        }

        private void ThrowGrenade(IGrenadeModel grenade)
        {
            grenade.Transform.gameObject.GetComponent<Rigidbody>()
                .AddForce(grenade.Transform.forward * grenade.ThrowForce, ForceMode.Impulse);
        }

        private void Exploded(Vector3 position)
        {
            _currentCount--;
        }
    }
}