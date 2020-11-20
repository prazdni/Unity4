using UnityEngine;

namespace Asteroids
{
    public class AbsenceRotation : IRotate
    {
        private Transform _ship;

        public AbsenceRotation(Transform transform)
        {
            _ship = transform;
        }
        
        public void Rotation(Vector3 direction)
        {
            _ship.rotation = Quaternion.identity;
        }
    }
}