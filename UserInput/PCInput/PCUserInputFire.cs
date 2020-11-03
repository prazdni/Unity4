using System;
using UnityEngine;

namespace Asteroids
{
    public class PCUserInputFire : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetMouseButtonDown(InputConstants.FIRE);
        }

        public bool IsKeyUp()
        {
            return Input.GetMouseButtonUp(InputConstants.FIRE);
        }
    }
}