using UnityEngine;

namespace Unity4.Lesson8
{
    public static class Extension
    {
        public static PlayerModel Copy(this PlayerModel player)
        {
            return new PlayerModel(player.Character, player.Grenades, player.Mines);
        }

        public static ICharacterModel Copy(this ICharacterModel character)
        {
            return new CharacterModel(character.Transform, character.ThrowGrenadePosition, character.SetMinePosition,
                character.HealthModel, character.SpeedModel, character.TakeRange);
        }

        public static T GetOrAddComponent<T>(this Transform transform) where T : Component
        {
            T component;
            
            if (transform.gameObject.TryGetComponent(out component))
            {
                return component;
            }

            return transform.gameObject.AddComponent<T>();
        }
    }
}