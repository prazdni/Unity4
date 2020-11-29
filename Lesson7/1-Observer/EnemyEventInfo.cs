using UnityEngine;

namespace Asteroids
{
    public struct EnemyEventInfo
    {
        public Transform SceneObjectTransform { get; }
        public bool IsOutOfBounds { get; }

        public EnemyEventInfo(Transform obj, bool isOutOfBounds)
        {
            SceneObjectTransform = obj;
            IsOutOfBounds = isOutOfBounds;
        }
    }
}