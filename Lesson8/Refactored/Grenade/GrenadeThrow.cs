using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrow : IGrenadeThrower
    {
        private Transform _throwPoint;
        private IGrenadeModel _grenade;
        private IPull<IGrenadeModel> _grenades;
        private bool _isGrenadeThrown;
        private ITakeObject _takeObject;
        private IGrenadeExplode _grenadeExplode;

        public GrenadeThrow(List<IEnemyHurtViewModel> enemies, IPull<IGrenadeModel> grenades, ITakeObject takeObject,
            Transform throwPoint)
        {
            _grenades = grenades;

            _throwPoint = throwPoint;

            _isGrenadeThrown = false;

            _takeObject = takeObject;

            _grenadeExplode =
                new GrenadeExplode(enemies, new Explosion(_grenade.ExplosionForce, _grenade.ExplosionRadius));
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                _grenade = _grenades.Get();
                _grenade.Transform.gameObject.SetActive(true);

                SetPosition();
                ThrowGrenade();

                _isGrenadeThrown = true;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_isGrenadeThrown)
            {
                //_grenades.Return(_grenade);
            }
        }

        private void SetPosition()
        {
            _grenade.Transform.gameObject.SetActive(true);
            _grenade.Transform.position = _throwPoint.position;
            _grenade.Transform.rotation = _throwPoint.rotation;
        }

        private void ThrowGrenade()
        {
            _grenade.Transform.gameObject.GetComponent<Rigidbody>()
                .AddForce(_grenade.Transform.forward * _grenade.ThrowForce, ForceMode.Impulse);
        }
    }
}