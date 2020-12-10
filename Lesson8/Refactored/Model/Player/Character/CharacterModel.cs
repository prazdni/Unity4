using UnityEngine;

namespace Unity4.Lesson8
{
    public class CharacterModel : ICharacterModel
    {
        public Transform Transform { get; }
        
        public Transform ThrowGrenadePosition { get; }
        
        public Transform SetMinePosition { get; }

        public IHealth Health { get; }
        
        public ISpeed Speed { get; }
        
        public float TakeRange { get; }
        
        public ITakeObject TakeObject { get; }

        public CharacterModel(Transform transform, Transform throwGrenadePosition, Transform setMinePosition,
            Health health, Speed speed, float takeRange)
        {
            Transform = transform;
            ThrowGrenadePosition = throwGrenadePosition;
            SetMinePosition = setMinePosition;
            Health = health;
            Speed = speed;
            TakeRange = takeRange;
            TakeObject = new TakeObject(throwGrenadePosition, takeRange);
        }
    }
}