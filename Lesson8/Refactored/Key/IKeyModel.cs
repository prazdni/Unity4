using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IKeyModel
    {
        Transform Transform { get; }
        Vector3 Position { get; }
    }
}