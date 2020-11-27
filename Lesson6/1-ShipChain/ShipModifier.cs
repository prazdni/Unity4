using Asteroids;
using UnityEditor.SceneManagement;

namespace Unity4.Lesson6
{
    public class ShipModifier
    {
        protected IShip _ship;
        protected ShipModifier NextModifier;

        public ShipModifier(IShip ship)
        {
            _ship = ship;
        }

        public void AddModifier(ShipModifier shipModifier)
        {
            if (NextModifier != null)
            {
                NextModifier.AddModifier(shipModifier);
            }
            else
            {
                NextModifier = shipModifier;
            }
        }
        
        public virtual void Handle() => NextModifier?.Handle();
    }
}