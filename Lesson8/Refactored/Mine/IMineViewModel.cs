using System;

namespace Unity4.Lesson8
{
    public interface IMineViewModel
    {
        event Action<float> OnCollision;

        void SetDamageOnCollision();
    }
}