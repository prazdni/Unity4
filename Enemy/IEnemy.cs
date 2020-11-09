using System;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemy : IExecute
    {
        Transform SceneEnemy { get; }
        Action<Transform> OnAction { get; }
    }
}