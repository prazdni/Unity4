using UnityEngine;

namespace Asteroids
{
    public interface IShip : IMove, IRotate, IAccelerate
    {
        Transform ShipTransform { get; }
    }
}