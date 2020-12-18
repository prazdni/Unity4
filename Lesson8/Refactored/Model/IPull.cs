using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public interface IPull<T> : IEnumerable<T>
    {
        int Count { get; }
        T Get();
        void Return(T obj);
    }
}