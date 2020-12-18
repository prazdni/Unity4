using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineViewModel : IMineViewModel
    {
        public event Action<Vector3, float> OnCollision = (v, f) => { };
        
        public float ExplosionForce => _mine.ExplosionForce;
        public float ExplosionRadius => _mine.ExplosionRadius;
        
        private IMineModel _mine;
        
        public MineViewModel(IMineModel mine)
        {
            _mine = mine;
        }
        
        public void SetDamageOnCollision(Vector3 position)
        {
            OnCollision.Invoke(position, _mine.Damage);
        }
    }
}