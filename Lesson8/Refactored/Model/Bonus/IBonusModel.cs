using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IBonusModel
    {
        Transform Transform { get; }
        EffectType EffectType { get; }
        float Effect { get; }
        float Duration { get; }
    }
}