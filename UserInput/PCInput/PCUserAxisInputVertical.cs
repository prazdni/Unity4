using System;
using UnityEngine;

namespace Asteroids
{
    public class PCUserAxisInputVertical : IUserAxisInput
    {
        public float GetAxis()
        {
            return Input.GetAxis(InputConstants.VERTICAL);
        }
    }
}