using UnityEngine;

namespace Unity4.Lesson8
{
    public interface IHelperCharacterModel
    {
        Transform Transform { get; }
        IBonusModel Bonus { get; }
    }
}