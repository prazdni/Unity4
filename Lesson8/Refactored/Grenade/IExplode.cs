using System;
using Asteroids;

namespace Unity4.Lesson8
{
    public interface IGrenadeExplode : IExecute
    {
        event Action<IGrenadeModel> IsExploded;
        void SetGrenade(IGrenadeModel grenade, float maxTimerValue);
    }
}