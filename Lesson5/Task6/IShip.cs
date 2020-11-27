using System;
using UnityEngine;

namespace Asteroids
{
    public interface IShip : IMove, IRotate, IAccelerate, IHealth
    {
        Transform ShipTransform { get; }
        Action<Transform> OnAction { get; }
        void SubscribeOnAction(Action<Transform> action);
    }
}