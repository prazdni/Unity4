using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IPullable
    {
        Transform Get();
        void Return(Transform transform);
    }
}