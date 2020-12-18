using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrow : IGrenadeThrower
    {
        private IPull<IExplosionViewModel<IGrenadeModel>> _grenades;
        private Transform _throwPoint;
        private bool _isGrenadeThrown;
        private ITakeObject _takeObject;
        private int _currentCount;

        public GrenadeThrow(IPull<IExplosionViewModel<IGrenadeModel>> grenades, Transform throwPoint, ITakeObject takeObject)
        {
            _throwPoint = throwPoint;

            _isGrenadeThrown = false;

            _takeObject = takeObject;

            _currentCount = 0;

            foreach (var grenade in grenades)
            {
                grenade.OnCollision += Exploded;
            }
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                if (_currentCount < _grenades.Count )
                {
                    _currentCount++;
                    var grenade = _grenades.Get();
                    grenade.DamageObj.Transform.gameObject.SetActive(true);
                    SetPosition(grenade);
                    ThrowGrenade(grenade);
                }
            }
        }

        private void SetPosition(IExplosionViewModel<IGrenadeModel> grenade)
        {
            grenade.DamageObj.Transform.gameObject.SetActive(true);
            grenade.DamageObj.Transform.position = _throwPoint.position;
            grenade.DamageObj.Transform.rotation = _throwPoint.rotation;
        }

        private void ThrowGrenade(IExplosionViewModel<IGrenadeModel> grenade)
        {
            grenade.DamageObj.Transform.gameObject.GetComponent<Rigidbody>()
                .AddForce(grenade.DamageObj.Transform.forward * grenade.DamageObj.ThrowForce, ForceMode.Impulse);
        }

        private void Exploded(Vector3 position)
        {
            _currentCount--;
        }
    }
}