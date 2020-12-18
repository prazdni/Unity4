using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    [Serializable]
    public class Health : IHealth
    {
        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        
        public float MaxHealth => _maxHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
    }
}