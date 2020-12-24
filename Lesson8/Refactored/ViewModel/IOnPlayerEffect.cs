using System;

namespace Unity4.Lesson8
{
    public interface IOnPlayerEffect<T>
    {
        event Action<T> OnEffect;
        void Effect(T effectTaker);
    }
}