using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayerModel _player;
        private ICharacterModel _character;
        private IPull<IGrenadeModel> _grenadePull;
        private IPull<IMineModel> _minePull;

        public IPlayerModel Create(ICharacterModel character, IPull<IGrenadeModel> grenadePull, IPull<IMineModel> minePull)
        {
            return new PlayerModel(character, grenadePull, minePull);
        }
    }
}