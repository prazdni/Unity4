﻿using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineSetter : IMineSetter
    {
        private Transform _setPoint;
        
        private IPull<IExplosionViewModel<IMineModel>> _minePull;
        
        public MineSetter(IPull<IExplosionViewModel<IMineModel>> minePull, Transform setPoint)
        {
            _setPoint = setPoint;
            
            _minePull = minePull;
        }
        
        public void Set()
        {
            SetPosition(_minePull.Get());
        }

        private void SetPosition(IExplosionViewModel<IMineModel> explosion)
        {
            explosion.DamageObj.Transform.gameObject.SetActive(true);
            explosion.DamageObj.Transform.position = _setPoint.position;
            explosion.DamageObj.Transform.rotation = _setPoint.rotation;
        }
    }
}