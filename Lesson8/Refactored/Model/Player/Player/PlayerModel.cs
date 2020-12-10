using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerModel : IPlayerModel
    {
        public ICharacterModel Character { get; }
        public IGrenadeModel Grenade { get; }
        public IMineModel Mine { get; }
        
        public PlayerModel(ICharacterModel character, IGrenadeModel grenade, IMineModel mine)
        {
            Character = character;
            Grenade = grenade;
            Mine = mine;
        }
    }
}