using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusThrowPull : IPull<IBonusModel>
    {
        private IBonusModel _bonus;
        private Vector3 _startPosition;
        public int Count { get; }
        
        public BonusThrowPull(IBonusModel bonusModel, Vector3 startPosition)
        {
            _bonus = bonusModel;
            _startPosition = startPosition;
            _bonus.Transform.gameObject.SetActive(false);
            Count = 1;
        }

        public IBonusModel Get()
        {
            _bonus.Transform.position = _startPosition;
            _bonus.Transform.gameObject.SetActive(true);
            return _bonus;
        }

        public void Return(IBonusModel obj)
        {
            obj.Transform.gameObject.SetActive(false);
        }

        public IEnumerator<IBonusModel> GetEnumerator()
        {
            yield return _bonus;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}