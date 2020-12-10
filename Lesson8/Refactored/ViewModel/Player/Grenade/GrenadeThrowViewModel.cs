using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrowViewModel : IGrenadeThrower
    {
        private Transform _throwPoint;
        private UpTimer _timer;
        private GrenadeModel _grenade;
        private float _throwForce;
        private bool _isGrenadeThrown;
        private IExplosionViewModel _explosion;
        private ITakeObject _takeObject;

        public GrenadeThrowViewModel(GrenadeModel grenade, ITakeObject takeObject, Transform throwPoint)
        {
            _grenade = grenade;
            _grenade.Transform.gameObject.SetActive(false);
            
            _throwPoint = throwPoint;
            _throwForce = grenade.ThrowForce;
            
            _timer = new UpTimer();
            _isGrenadeThrown = false;
            _explosion =
                new ExplosionViewModel(grenade.ExplosionForce, grenade.ExplosionRadius, grenade.Damage);

            _takeObject = takeObject;
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                SetGrenade();
                ThrowGrenade();

                _isGrenadeThrown = true;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_isGrenadeThrown)
            {
                TryExplodeGrenade(deltaTime);
            }
        }

        private void SetGrenade()
        {
            _grenade.Transform.gameObject.SetActive(true);
            _grenade.Transform.position = _throwPoint.position;
            _grenade.Transform.rotation = _throwPoint.rotation;
        }

        private void ThrowGrenade()
        {
            _grenade.Transform.gameObject.GetComponent<Rigidbody>()
                .AddForce(_throwPoint.forward * _throwForce, ForceMode.Impulse);
        }

        private void TryExplodeGrenade(float deltaTime)
        {
            _timer.UpTimerTick(deltaTime);
            
            if (Mathf.Approximately(_timer.CurrentValue, _timer.MAXValue))
            {
                _isGrenadeThrown = false;
                _explosion.Explode(_grenade.Transform.position);
            }
        }
    }
}