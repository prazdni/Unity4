using UnityEngine;

namespace Unity4.Lesson8
{
    public interface ICharacterModel
    {
        Transform Transform { get; }
        
        Transform ThrowGrenadePosition { get; }
        
        Transform SetMinePosition { get; }

        IHealth Health { get; }
        
        ISpeed Speed { get; }
        
        float TakeRange { get; }
        
        ITakeObject TakeObject { get; }
    }
}