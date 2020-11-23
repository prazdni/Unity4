using Asteroids;

namespace Unity4.Lesson6
{
    public class HalfSpeedReducer : ShipModifier
    {
        public HalfSpeedReducer(IShip ship) : base(ship)
        {
        }

        public override void Handle()
        {
            _ship.Speed /= 2;
            
            base.Handle();
        }
    }
}