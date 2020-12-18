using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerModel : IPlayerModel
    {
        public ICharacterModel Character { get; }
        public IPull<IExplosionViewModel<IGrenadeModel>> Grenades { get; }
        public IPull<IExplosionViewModel<IMineModel>> Mines { get; }
        
        public PlayerModel(ICharacterModel character, IPull<IExplosionViewModel<IGrenadeModel>> grenades, IPull<IExplosionViewModel<IMineModel>> mines)
        {
            Character = character;
            Grenades = grenades;
            Mines = mines;
        }
    }
}