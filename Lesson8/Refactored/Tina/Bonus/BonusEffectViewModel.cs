using System;
using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusEffectViewModel : IOnPlayerEffect<IBonusModel>, IExecute
    {
        public event Action<IBonusModel> OnEffect = f => { };

        private IEffect _effect;
        
        private UpTimer _timer;
        private bool _isBonusTaken;

        public BonusEffectViewModel(IPlayerModel player)
        {
            _effect = new Effect(player);
            _isBonusTaken = false;
        }
        
        public void Execute(float deltaTime)
        {
            if (_isBonusTaken)
            {
                if (Mathf.Approximately(_timer.CurrentValue, _timer.MAXValue))
                {
                    _effect.ReturnToDefault();
                    _isBonusTaken = false;
                }
            }
        }

        public void Effect(IBonusModel effectTaker)
        {
            if (!_isBonusTaken)
            {
                _effect.SetEffect(effectTaker.EffectType, effectTaker.Effect);
                _timer = new UpTimer(0, effectTaker.Duration);
                _isBonusTaken = true;
            }
            
            OnEffect.Invoke(effectTaker);
        }
    }
}