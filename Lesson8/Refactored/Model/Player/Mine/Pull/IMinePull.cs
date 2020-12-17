using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IMinePull
    {
        int Count { get; }
        IMineModel Get();
        void Return(IMineModel mine);
    }
}