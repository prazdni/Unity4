using System;
using UnityEngine;

namespace Asteroids
{
    public class PCUserAxisInputHorizontal : IUserAxisInput
    {
        public float GetAxis()
        {
            return Input.GetAxis(InputConstants.HORIZONTAL);
        }
    }
}