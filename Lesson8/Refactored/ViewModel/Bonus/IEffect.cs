﻿namespace Unity4.Lesson8
{
    public interface IEffect
    {
        void SetEffect(EffectType type, float effect);
        void SetEffect(IBonusModel bonus);
        void ReturnToDefault();
    }
}