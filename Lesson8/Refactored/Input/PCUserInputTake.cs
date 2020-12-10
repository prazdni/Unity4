﻿using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class PCUserInputTake : IUserKeyInput
    {
        public bool IsKeyDown()
        {
            return Input.GetKeyDown(InputConstants.TAKE);
        }

        public bool IsKeyUp()
        {
            return Input.GetKeyUp(InputConstants.TAKE);
        }
    }
}