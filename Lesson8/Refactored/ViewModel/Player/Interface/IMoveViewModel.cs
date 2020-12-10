using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMoveViewModel
    {
        void Move(Vector3 direction, float deltaTime);
    }
}