using UnityEngine;

namespace Asteroids
{
    public class PCUserInputAcceleration : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(InputConstants.ACCELERATION);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(InputConstants.ACCELERATION);
        }
    }
}