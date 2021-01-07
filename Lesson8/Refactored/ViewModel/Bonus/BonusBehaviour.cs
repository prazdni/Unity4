using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusBehaviour : IExecute
    {
        private IBonusList _bonuses;
        private float _sumDelta;
        
        public BonusBehaviour(IBonusList bonuses)
        {
            _bonuses = bonuses;
            _sumDelta = 0;
        }

        public void Execute(float deltaTime)
        {
            foreach (var bonus in _bonuses)
            {
                switch (bonus.EffectType)
                {
                    case EffectType.None:
                        break;
                    case EffectType.Speed:
                        RotateBonus(bonus, deltaTime);
                        break;
                    case EffectType.Health:
                        MoveBonus(bonus, deltaTime);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void RotateBonus(IBonusModel bonus, float deltaTime)
        {
            bonus.Transform.Rotate(Vector3.up, deltaTime);
        }

        private void MoveBonus(IBonusModel bonus, float deltaTime)
        {
            _sumDelta += deltaTime;
            var position = bonus.Transform.position;
            position.Set(position.x, Mathf.PingPong(_sumDelta, 1.0f), position.z);
        }
    }
}