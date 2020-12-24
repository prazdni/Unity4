﻿using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineSetter : IMineSetter
    {
        private Transform _setPoint;
        
        private IPull<IMineModel> _minePull;
        
        public MineSetter(IPull<IMineModel> minePull, Transform setPoint)
        {
            _setPoint = setPoint;
            
            _minePull = minePull;
        }
        
        public void Set()
        {
            SetPosition(_minePull.Get());
        }

        private void SetPosition(IMineModel explosion)
        {
            explosion.Transform.gameObject.SetActive(true);
            explosion.Transform.position = _setPoint.position;
            explosion.Transform.rotation = _setPoint.rotation;
        }
    }
}