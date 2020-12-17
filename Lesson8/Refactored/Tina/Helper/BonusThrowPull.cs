using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusThrowPull : IPullable<IBonusModel>
    {
        private IBonusModel _bonus;
        private Vector3 _startPosition;
        
        public BonusThrowPull(IBonusModel bonusModel, Vector3 startPosition)
        {
            _bonus = bonusModel;
            _startPosition = startPosition;
            _bonus.Transform.gameObject.SetActive(false);
        }
        
        public IBonusModel Get()
        {
            _bonus.Transform.position = _startPosition;
            _bonus.Transform.gameObject.SetActive(true);
            return _bonus;
        }

        public void Return(IBonusModel transform)
        {
            transform.Transform.gameObject.SetActive(false);
        }
    }
}