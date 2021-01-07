using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMove
    {
        void Move(Vector3 direction, float deltaTime);
    }
}