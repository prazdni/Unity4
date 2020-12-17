using System;

namespace Unity4.Lesson8
{
    public class HealthViewModel : IOnPlayerEffect<float>
    {
        public event Action<float> OnEffect = f => { };
        private Health _health;
        
        public HealthViewModel(Health health)
        {
            _health = health;
        }

        public void Effect(float effectTaker)
        {
            _health.CurrentHealth -= effectTaker;
            OnEffect.Invoke(effectTaker);
        }
    }
}