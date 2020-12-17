using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    [Serializable]
    public class BonusConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private EffectType effectType;
        [SerializeField] private float _bonusEffect;
        [SerializeField] private float _duration;

        public Transform Prefab => _prefab;

        public EffectType EffectType => effectType;

        public float BonusEffect => _bonusEffect;

        public float Duration => _duration;
    }
}