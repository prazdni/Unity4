using System;
using UnityEngine;

namespace Asteroids
{
    public interface IShip : IMove, IRotate, IAccelerate, IHealth
    {
        Transform ShipTransform { get; }
        event Action<Transform> ShipAction;

        void OnAction(Transform transform);
    }
}