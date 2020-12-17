using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IPullable<T>
    {
        T Get();
        void Return(T transform);
    }
}