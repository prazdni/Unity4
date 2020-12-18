using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class ExplodeMine : IExplode<IMineModel>
    {
        public event Action<IMineModel> IsExploded = b => { };

        private IPull<IEnemyHurtViewModel> _enemies;
        private UpTimer _timer;
        private IExplosion _explosion;
        private IMineModel _mine;

        public ExplodeMine(IPull<IEnemyHurtViewModel> enemies)
        {
            _enemies = enemies;
            _explosion = new Explosion();
            _timer = new UpTimer();
        }
        
        public void Execute(float deltaTime)
        {
            _timer.UpTimerTick(deltaTime);
            
            if (Mathf.Approximately(_timer.CurrentValue, _timer.MAXValue))
            {
                ApplyDamage();
                IsExploded.Invoke(_mine);
            }
        }

        
        public void SetExplosionObject(IMineModel explosionObject)
        {
            _mine = explosionObject;
            _explosion.SetExplosionParameters(explosionObject.ExplosionForce, explosionObject.ExplosionRadius);
            _timer.ResetTimerWithNewMaxValue(explosionObject.Duration);
        }

        private void ApplyDamage()
        {
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