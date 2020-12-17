using System;

namespace Unity4.Lesson8
{
    public interface IKeyViewModel
    {
        event Action OnKeyTake;
        void OnTake();
    }
}