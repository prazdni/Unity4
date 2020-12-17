using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeExplode : IGrenadeExplode
    {
        private UpTimer _timer;
        private List<IEnemyDamageViewModel> _enemies;
        private IGrenadeModel _grenade;
        private IExplosion _explosion;
        private bool _isThrown;

        public GrenadeExplode(List<IEnemyDamageViewModel> enemies, IExplosion explosion)
        {
            _enemies = enemies;
            _timer = new UpTimer(0.0f, 3.0f);
            _explosion = explosion;
        }
        
        public void IsGrenadeThrown(bool isThrown)
        {
            _isThrown = isThrown;
        }

        public void Execute(float deltaTime)
        {
            if (_isThrown)
            {
                _timer.UpTimerTick(deltaTime);
            
                if (Mathf.Approximately(_timer.CurrentValue, _timer.MAXValue))
                {
                    _isThrown = false;
                    ApplyEnemyDamage();
                }
            }
        }

        private void ApplyEnemyDamage()
        {
            _explosion.Explode(_grenade.Transform.position);

            foreach (var enemy in _enemies)
            {
                if ((enemy.Transform.position - _grenade.Transform.position).sqrMagnitude < Mathf.Pow(_grenade.ExplosionRadius, 2))
                {
                    enemy.DamageEnemy(_grenade.Damage);
                }
            }
        }
    }
}