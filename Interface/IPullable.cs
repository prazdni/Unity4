using UnityEngine;

namespace Asteroids
{
    public interface IPullable<T>
    {
        T Get();
        void Return(T returnObject);
    }
}