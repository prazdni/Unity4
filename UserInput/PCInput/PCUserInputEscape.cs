using UnityEngine;

namespace Asteroids
{
    public class PCUserInputEscape : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(InputConstants.ESCAPE);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(InputConstants.ESCAPE);
        }
    }
}