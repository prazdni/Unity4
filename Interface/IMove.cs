namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; set; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}