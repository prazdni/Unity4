using System;
using UnityEngine;

namespace Asteroids
{
    public interface IShip : IMove, IRotate, IAccelerate
    {
        Transform ShipTransform { get; }
        Action<Transform> OnAction { get; }
    }
}