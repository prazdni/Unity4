using UnityEngine;

namespace Asteroids
{
    public interface IReturnable
    {
        bool ShouldReturn(Transform sceneObject);
    }
}