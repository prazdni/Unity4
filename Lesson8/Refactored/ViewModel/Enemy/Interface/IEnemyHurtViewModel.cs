using System;

namespace Unity4.Lesson8
{
    public interface IEnemyHurtViewModel
    {
       event  Action<float> OnEnemyHurt;
    }
}