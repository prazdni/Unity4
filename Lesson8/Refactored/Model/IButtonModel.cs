using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IButtonModel
    {
        Transform Transform { get; }
        IDoorModel Door { get; }
    }
}