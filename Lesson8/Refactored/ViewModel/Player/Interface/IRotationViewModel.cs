using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IRotationViewModel
    {
        void Rotate(Vector3 direction, float deltaTime);
    }
}