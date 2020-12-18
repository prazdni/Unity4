using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerModel : IPlayerModel
    {
        public ICharacterModel Character { get; }
        public IPull<IGrenadeModel> Grenades { get; }
        public IPull<IExplosionViewModel<>> Mines { get; }
        
        public PlayerModel(ICharacterModel character, IPull<IGrenadeModel> grenades, IPull<IMineModel> mines)
        {
            Character = character;
            Grenades = grenades;
            Mines = mines;
        }
    }
}