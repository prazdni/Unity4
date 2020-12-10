using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class PCUserInputMine : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(InputConstants.MINE);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(InputConstants.MINE);
        }
    }
}