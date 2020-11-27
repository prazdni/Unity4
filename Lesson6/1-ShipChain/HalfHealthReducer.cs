using Asteroids;

namespace Unity4.Lesson6
{
    public class HalfHealthReducer : ShipModifier
    {
        public HalfHealthReducer(IShip ship) : base(ship)
        {
        }

        public override void Handle()
        {
            _ship.Health /= 2;
            base.Handle();
        }
    }
}