using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ExplodeGrenade : IExplode<IGrenadeModel>
    {
        private UpTimer _timer;
        public event Action<IGrenadeModel> IsExploded = b => { };

        private IPull<IEnemyHurtViewModel> _enemies;
        private IGrenadeModel _grenade;
        private IExplosion _explosion;

        public ExplodeGrenade(IPull<IEnemyHurtViewModel> enemies)
        {
            _enemies = enemies;
            _explosion = new Explosion();
            _timer = new UpTimer();
        }
        
         public void SetExplosionObject(IGrenadeModel grenade, float maxExplosionTime)
        {
            _grenade = grenade;
            _explosion.SetExplosionParameters(grenade.ExplosionForce, grenade.ExplosionForce);
            _timer.ResetTimerWithNewMaxValue(maxExplosionTime);
        }
        
        public void Execute(float deltaTime)
        {
            _timer.UpTimerTick(deltaTime);
            
            if (Mathf.Approximately(_timer.CurrentValue, _timer.MAXValue))
            {
                ApplyDamage();
                IsExploded.Invoke(_grenade);
            }
        }

        private void ApplyDamage()
        {
            _explosion.Explode(_grenade.Transform.position);

            foreach (var enemy in _enemies)
            {
                if ((enemy.Transform.position - _grenade.Transform.position).sqrMagnitude <
                    Mathf.Pow(_grenade.ExplosionRadius, 2)) 
                {
                    enemy.HurtEnemy(_grenade.Damage);
                }
            }
        }
    }
}