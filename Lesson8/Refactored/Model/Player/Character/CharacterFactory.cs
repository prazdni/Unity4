using UnityEngine;

namespace Unity4.Lesson8
{
    public class CharacterFactory : IFactory<CharacterConfiguration, ICharacterModel>
    { 
        public ICharacterModel Create(CharacterConfiguration obj)
        {
            var characterTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            return new CharacterModel(characterTransform, obj.ThrowGrenadePosition,
                obj.SetMinePosition, obj.HealthModel, obj.SpeedModel, obj.TakeRange);
        }
    }
}