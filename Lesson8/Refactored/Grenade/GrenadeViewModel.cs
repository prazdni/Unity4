using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeViewModel : IExplosionViewModel<IGrenadeModel>
    {
        public event Action<Vector3> OnCollision = v => { };
        
        public IGrenadeModel DamageObj { get; }

        public GrenadeViewModel(IGrenadeModel grenadeModel)
        {
            DamageObj = grenadeModel;
        }
        
        public void SetDamageOnCollision(Vector3 position)
        {
            OnCollision.Invoke(position);
        }
    }
}