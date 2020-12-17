using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "Bonuses", menuName = "ScriptableObjects/Bonuses", order = 0)]
    public class BonusesConfiguration : ScriptableObject
    {
        [SerializeField] private List<BonusConfiguration> _bonuses;

        public List<BonusConfiguration> Bonuses => _bonuses;
    }
}