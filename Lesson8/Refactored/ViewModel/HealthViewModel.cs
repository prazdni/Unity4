using System;

namespace Unity4.Lesson8
{
    public class HealthViewModel : IOnPlayerEffect<float>
    {
        public event Action<float> OnEffect = f => { };
        private HealthModel _healthModel;
        
        public HealthViewModel(HealthModel healthModel)
        {
            _healthModel = healthModel;
        }

        public void Effect(float effectTaker)
        {
            _healthModel.CurrentHealth -= effectTaker;
            OnEffect.Invoke(effectTaker);
        }
    }
}