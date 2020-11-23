namespace Asteroids
{
    public class Health
    {
        public float Current { get; private set; }
        
        public float Max { get; }
        
        public Health(float max)
        {
            Max = max;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
    }
}