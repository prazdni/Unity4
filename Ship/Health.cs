namespace Asteroids
{
    public class Health
    {
        private readonly int _maxHp;

        public int MAXHp => _maxHp;
        public float CurrentHp { get; private set; }
        
        public Health(int maxHp)
        {
            _maxHp = maxHp;
            CurrentHp = _maxHp;
        }

        public void ApplyDamage(float value)
        {
            CurrentHp -= value;
        }
    }
}