using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class PCUserInputGrenade : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(InputConstants.GRENADE);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(InputConstants.GRENADE);
        }
    }
}