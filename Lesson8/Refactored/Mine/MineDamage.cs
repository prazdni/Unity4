using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineDamage : IMineSetter
    {
        private Transform _setPoint;
        
        private IExplosion _explosion;
        private IPull<IMineModel> _minePull;
        
        private Queue<IMineModel> _sceneMines;
        private int _minesCount;
        private bool _isMineSet;
        
        public MineDamage(ISimpleEnemyModel enemyModel, IPull<IMineModel> minePull, Transform setPoint)
        {
            _minesCount = minePull.Count;
            _isMineSet = false;
            
            _sceneMines = new Queue<IMineModel>();
            
            _setPoint = setPoint;
            
            _minePull = minePull;
            //_explosion = new ExplosionViewModel(mine.ExplosionForce, mine.ExplosionRadius, mine.Damage);
        }
        
        public void Set()
        {
            if (_sceneMines.Count <= _minesCount)
            {
                _sceneMines.Enqueue(_minePull.Get());
            }
            else
            {
                _minePull.Return(_sceneMines.Dequeue());
                _sceneMines.Enqueue(SetPosition(_minePull.Get()));
            }
        }

        public void Execute(float deltaTime)
        {
            
        }
        
        private IMineModel SetPosition(IMineModel mine)
        {
            mine.Transform.gameObject.SetActive(true);
            mine.Transform.position = _setPoint.position;
            mine.Transform.rotation = _setPoint.rotation;

            return mine;
        }
    }
}