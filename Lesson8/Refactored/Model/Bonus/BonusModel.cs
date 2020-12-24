using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusModel : IBonusModel
    {
        private Transform _transform;
        private EffectType _effectType;
        private float _effect;
        private float _duration;

        public Transform Transform => _transform;

        public EffectType EffectType => _effectType;

        public float Effect => _effect;

        public float Duration => _duration;

        public BonusModel(BonusConfiguration bonus)
        {
            _transform = Object.Instantiate(bonus.Prefab);
            _effectType = bonus.EffectType;
            _effect = bonus.BonusEffect;
            _duration = bonus.Duration;
        }
    }
}