using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerFactory
    {
        private IPlayerModel _player;
        private ICharacterModel _character;
        private IGrenadeModel _grenade;
        private IPullable _minePull;
        
        public PlayerFactory(CharacterConfiguration character, GrenadeConfiguration grenade, MineConfiguration mine)
        {
            var sceneCharacter = Object.Instantiate(character.Prefab);
            _character =
                new CharacterModel(sceneCharacter, character.ThrowGrenadePosition, character.SetMinePosition,
                    character.Health, character.Speed, character.TakeRange);

            var sceneGrenade = Object.Instantiate(grenade.Prefab);
            _grenade = new GrenadeModel(sceneGrenade, grenade.ThrowForce, grenade.ExplosionForce,
                grenade.ExplosionRadius, grenade.Damage);
            
            _minePull = new MinePull(mine);
            
            _player = new PlayerModel();
        }
        
        public 
    }
}