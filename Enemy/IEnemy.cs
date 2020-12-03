using System;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemy : IExecute
    {
        Transform SceneEnemy { get; }
        event Action<EnemyEventInfo> EnemyAction;

        void OnAction(EnemyEventInfo info);
    }
}