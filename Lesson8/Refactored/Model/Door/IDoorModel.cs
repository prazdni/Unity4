using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IDoorModel
    {
        Transform Transform { get; }
        Animator Animator { get; }
        Vector3 Position { get; }
        Vector3 Rotation { get; }
    }
}