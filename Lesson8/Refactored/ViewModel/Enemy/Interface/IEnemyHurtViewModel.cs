using System;

namespace Unity4.Lesson8.Interface
{
    public interface IEnemyHurtViewModel
    {
       event  Action<float> OnEnemyHurt;
    }
}