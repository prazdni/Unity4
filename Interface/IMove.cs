namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vectical, float deltaTime);
    }
}