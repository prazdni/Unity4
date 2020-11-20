using UnityEngine;

namespace Lesson5.Decorator
{
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}