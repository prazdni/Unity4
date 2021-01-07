using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class PCUserInputMine : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(Constants.MINE);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(Constants.MINE);
        }
    }
}