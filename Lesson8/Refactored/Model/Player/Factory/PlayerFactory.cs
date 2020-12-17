using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerFactory : IPlayerFactory
    {
        private IPlayerModel _player;
        private ICharacterModel _character;
        private IPull _pull;
        private IMinePull _minePull;
        
        public PlayerFactory(CharacterConfiguration character, GrenadeConfiguration grenade, MineConfiguration mine)
        {
            var sceneCharacter = Object.Instantiate(character.Prefab);
            _character =
                new CharacterModel(sceneCharacter, character.ThrowGrenadePosition, character.SetMinePosition,
                    character.Health, character.Speed, character.TakeRange);

            _pull = new GrenadePull(grenade);
            
            _minePull = new MinePull(mine);
            
            _player = new PlayerModel(_character, _pull, _minePull);
        }

        public PlayerModel ChangeCharacter(CharacterConfiguration character, Transform scenePoint)
        {
            var sceneCharacter = Object.Instantiate(character.Prefab, scenePoint.position, scenePoint.rotation);
            _character =
                new CharacterModel(sceneCharacter, character.ThrowGrenadePosition, character.SetMinePosition,
                    character.Health, character.Speed, character.TakeRange);
            
            return new PlayerModel(_character, _pull, _minePull);
        }

        public PlayerModel ChangeGrenadePull(GrenadeConfiguration grenade)
        {
            return new PlayerModel(_character, new GrenadePull(grenade), _minePull);
        }

        public PlayerModel ChangeMinePull(MineConfiguration mine)
        {
            return new PlayerModel(_character, _pull, new MinePull(mine));
        }
    }
}