using UnityEngine;

namespace Unity4.Lesson8
{
    public class CharacterModel : ICharacterModel
    {
        public Transform Transform { get; }
        
        public Transform ThrowGrenadePosition { get; }
        
        public Transform SetMinePosition { get; }

        public IHealthModel HealthModel { get; }
        
        public ISpeedModel SpeedModel { get; }
        
        public float TakeRange { get; }
        
        public ITakeObject TakeObject { get; }

        public CharacterModel(Transform transform, Transform throwGrenadePosition, Transform setMinePosition,
            IHealthModel healthModel, ISpeedModel speedModel, float takeRange)
        {
            Transform = transform;
            ThrowGrenadePosition = throwGrenadePosition;
            SetMinePosition = setMinePosition;
            HealthModel = healthModel;
            SpeedModel = speedModel;
            TakeRange = takeRange;
            TakeObject = new TakeObject(throwGrenadePosition, takeRange);
        }
    }
}