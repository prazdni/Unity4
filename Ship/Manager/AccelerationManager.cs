using Asteroids;

namespace Asteroids
{
    public class AccelerationManager : IExecute
    {
        private IUserKeyInput _acceleration;
        private IShip _ship;

        public AccelerationManager(IShip ship)
        {
            _ship = ship;
            _acceleration = new PCUserInputAcceleration();
        }
        
        public void Execute(float deltaTime)
        {
            if (_acceleration.IsKeyDown())
            {
                _ship.AddAcceleration();
            }

            if (_acceleration.IsKeyUp())
            {
                _ship.RemoveAcceleration();
            }
        }
    }
}