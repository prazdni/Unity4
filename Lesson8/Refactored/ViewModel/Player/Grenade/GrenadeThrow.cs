using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeThrow : IGrenadeThrow
    {
        private IPull<IGrenadeModel> _grenades;
        private Transform _throwPoint;
        private ITakeObject _takeObject;
        
        private List<IGrenadeModel> _addedGrenades;
        private List<UpTimer> _timers;

        public GrenadeThrow(IPull<IGrenadeModel> grenades, Transform throwPoint, ITakeObject takeObject)
        {
            _grenades = grenades;
            
            _throwPoint = throwPoint;
            
            _takeObject = takeObject;
            
            _addedGrenades = new List<IGrenadeModel>();
            _timers = new List<UpTimer>();
        }

        public void Throw()
        {
            if (!_takeObject.IsObjectTaken)
            {
                if (_grenades.Count != 0)
                {
                    var grenade = _grenades.Get();
                    
                    grenade.Transform.gameObject.SetActive(true);
                    SetPosition(grenade);
                    ThrowGrenade(grenade);
                    
                    _addedGrenades.Add(grenade);
                    _timers.Add(new UpTimer(0, grenade.Duration));
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

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _addedGrenades.Count; i++)
            {
                _timers[i].UpTimerTick(deltaTime);
                if (!_addedGrenades[i].Transform.gameObject.activeSelf ||
                    Mathf.Approximately(_timers[i].CurrentValue, _timers[i].MAXValue))
                {
                    _addedGrenades.RemoveAt(i);
                    _timers.RemoveAt(i);
                }
            }
        }
    }
}