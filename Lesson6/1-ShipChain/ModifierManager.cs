using Asteroids;

namespace Unity4.Lesson6
{
    public class ModifierManager
    {
        private ShipModifier _rootShipModifier;
        
        public ModifierManager(IShip ship)
        {
            _rootShipModifier = new ShipModifier(ship);
            _rootShipModifier.AddModifier(new HalfHealthReducer(ship));
            _rootShipModifier.AddModifier(new HalfSpeedReducer(ship));
        }

        public void ModifyShip()
        {
            _rootShipModifier.Handle();
        }
    }
}