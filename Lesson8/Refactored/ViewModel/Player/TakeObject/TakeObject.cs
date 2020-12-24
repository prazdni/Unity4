using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class TakeObject : ITakeObject
    {
        private List<Transform> _cubes;
        private Transform _cube;
        private Transform _takePoint;
        private float _takeRange;
        private bool _isObjectTaken;

        public bool IsObjectTaken => _isObjectTaken;

        public TakeObject(Transform takePoint, float takeRange)
        {
            _takeRange = takeRange;
            _takePoint = takePoint;
            _cubes = new List<Transform>();
            _isObjectTaken = false;
        }
        
        public void Take()
        {
            if (!_isObjectTaken)
            {
                _cubes.Clear();

                FindTakeObjects(Constants.EXPLOSIONOBJECTSQUANTITY, "ObjectToTake");

                if (_cubes.Count >= 1)
                {
                    _cube = FindMinTransform();
                    _isObjectTaken = true;
                }
            }
            else
            {
                _isObjectTaken = false;
            }
        }

        private void FindTakeObjects(int count, string tag)
        {
            var hitColliders = new Collider[count];
            Physics.OverlapSphereNonAlloc(_takePoint.position, _takeRange, hitColliders);

            foreach (var coll in hitColliders)
            {
                if (coll.gameObject.CompareTag(tag))
                {
                    _cubes.Add(coll.gameObject.transform);
                }
            }
        }

        private Transform FindMinTransform()
        {
            var min = (_cubes[0].position - _takePoint.position).sqrMagnitude;
            var currentTransform = _cubes[0];
            
            for (int i = 1; i < _cubes.Count; i++)
            {
                if ((_cubes[i].position - _takePoint.position).sqrMagnitude < min)
                {
                    min = (_cubes[i].position - _takePoint.position).sqrMagnitude;
                    currentTransform = _cubes[i];
                }
            }

            return currentTransform;
        }

        public void Execute(float deltaTime)
        {
            if (_isObjectTaken)
            {
                _cube.position = _takePoint.position;
                _cube.rotation = _takePoint.rotation;
            }
        }
    }
}