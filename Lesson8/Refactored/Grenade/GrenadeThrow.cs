using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrow : IGrenadeThrower
    {
        private Transform _throwPoint;
        private IPull<IGrenadeModel> _grenades;
        private bool _isGrenadeThrown;
        private ITakeObject _takeObject;
        private IExplode<IGrenadeModel> _explode;

        public GrenadeThrow(IPull<IEnemyHurtViewModel> enemies, IPull<IGrenadeModel> grenades, ITakeObject takeObject,
            Transform throwPoint)
        {
            _grenades = grenades;

            _throwPoint = throwPoint;

            _isGrenadeThrown = false;

            _takeObject = takeObject;

            _explode = new ExplodeGrenade(enemies);
            _explode.IsExploded += model =>
            {
                _grenades.Return(model);
                _isGrenadeThrown = false;
            };
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                var grenade = _grenades.Get();
                grenade.Transform.gameObject.SetActive(true);

                SetPosition(grenade);
                ThrowGrenade(grenade);

                _isGrenadeThrown = true;
                
                _explode.SetExplosionObject(grenade);
            }
        }

        public void Execute(float deltaTime)
        {
            if (_isGrenadeThrown)
            {
                _explode.Execute(deltaTime);
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
    }
}