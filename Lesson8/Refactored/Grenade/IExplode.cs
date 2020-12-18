using System;
using Asteroids;

namespace Unity4.Lesson8
{
    public interface IExplode<T> : IExecute
    {
        event Action<T> IsExploded;
        void SetExplosionObject(T explosionObject);
    }
}