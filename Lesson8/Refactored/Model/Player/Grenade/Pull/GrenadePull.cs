using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadePull : IPull<IGrenadeModel>
    {
        private List<IGrenadeModel> _grenades;
        private GrenadeConfiguration _grenadeConfig;
        public int Count { get; }

        public GrenadePull(GrenadeConfiguration grenade)
        {
            Count = grenade.Quantity;
            
            _grenadeConfig = grenade;

            var grenadeModel = new GrenadeModel(Object.Instantiate(grenade.Prefab, Vector3.zero, Quaternion.identity),
                grenade.ThrowForce, grenade.ExplosionForce, grenade.ExplosionRadius, grenade.Damage);

            _grenades = new List<IGrenadeModel>();

            for (int i = 0; i < Count; i++)
            {
                _grenades.Add(grenadeModel);
            }
            
            foreach (var g in _grenades)
            {
                g.Transform.gameObject.SetActive(false);
            }
        }

        

        public IGrenadeModel Get()
        {
            var grenade = _grenades.Find(g => !g.Transform.gameObject.activeSelf);

            if (grenade == null)
            {
                var newGrenadeModel = new GrenadeModel(Object.Instantiate(_grenadeConfig.Prefab, Vector3.zero, Quaternion.identity),
                    _grenadeConfig.ThrowForce, _grenadeConfig.ExplosionForce, _grenadeConfig.ExplosionRadius, _grenadeConfig.Damage);

                newGrenadeModel.Transform.gameObject.SetActive(false);
                _grenades.Add(newGrenadeModel);
            }

            return _grenades.Find(g => !g.Transform.gameObject.activeSelf);
        }

        public void Return(IGrenadeModel grenade)
        {
            grenade.Transform.gameObject.SetActive(false);
        }
    }
}