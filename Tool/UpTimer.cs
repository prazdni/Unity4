using System.Net.Http.Headers;

namespace Asteroids
{
    public class UpTimer
    {
        private float _minValue;
        private float _maxValue;
        private float _sumValue;

        public float MAXValue => _maxValue;

        public float MINValue => _minValue;

        public float CurrentValue => _sumValue;

        public UpTimer(float min = 0.0f, float max = 1.0f)
        {
            _minValue = min;
            _maxValue = max;
            _sumValue = min;
        }

        public float UpTimerTick(float deltaTime)
        {
            _sumValue += deltaTime;
            return _sumValue;
        }

        public void ResetTimer()
        {
            _sumValue = _minValue;
        }

        public void ResetTimerWithNewMaxValue(float maxValue)
        {
            _sumValue = _minValue;
            _maxValue = maxValue;
        }
    }
}