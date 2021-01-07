using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IRotation
    {
        void Rotate(Vector3 direction, float deltaTime);
    }
}