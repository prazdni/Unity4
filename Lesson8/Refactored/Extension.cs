namespace Unity4.Lesson8
{
    public static class Extension
    {
        public static PlayerModel Copy(this PlayerModel player)
        {
            return new PlayerModel(player.Character, player.Grenade, player.Mine);
        }

        public static ICharacterModel Copy(this ICharacterModel character)
        {
            return new CharacterModel(character.Transform, character.ThrowGrenadePosition, character.SetMinePosition,
                character.Health, character.Speed, character.TakeRange);
        }
    }
}