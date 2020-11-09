namespace Asteroids
{
    public class Speed
    {
        public float Current { get; private set; }
        
        public float Max { get; }
        
        public Speed(float max)
        {
            Max = max;
            Current = max;
        }

        public void ChangeCurrentHealth(float speed)
        {
            Current = speed;
        }
    }
}