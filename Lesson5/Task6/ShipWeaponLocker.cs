using Lesson5.Proxy;

namespace Asteroids
{
    public class ShipWeaponLocker
    {
        public bool IsLocked { get; set; }

        public ShipWeaponLocker(bool isLocked)
        {
            IsLocked = isLocked;
        }
    }
}