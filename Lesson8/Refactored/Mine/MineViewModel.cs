using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineViewModel : IExplosionViewModel<IMineModel>
    {
        public event Action<Vector3> OnCollision = v => { };

        public IMineModel DamageObj { get; }

        public MineViewModel(IMineModel mine)
        {
            DamageObj = mine;
        }
        
        public void Explode(Vector3 position)
        {
            OnCollision.Invoke(position);
        }
    }
}