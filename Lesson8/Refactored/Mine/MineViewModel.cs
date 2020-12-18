using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineViewModel : IMineViewModel
    {
        public event Action<Vector3> OnCollision = v => { };

        private IExplode<IMineModel> _explodeMine;
        private IPull<ISimpleEnemyModel> _enemies;
        private float _explosionForce;
        private float _explosionRadius;

        public MineViewModel(IPull<ISimpleEnemyModel> enemies, float explosionForce, float explosionRadius)
        {
            _enemies = enemies;
            _explosionForce = explosionForce;
            _explosionRadius = explosionRadius;
            _explodeMine = new ExplodeMine(explosionForce, explosionRadius);
        }
        
        public void SetDamageOnCollision(Vector3 position)
        {
            foreach (var enemy in _enemies)
            {
                throw new NotImplementedException();
            }
        }
    }
}