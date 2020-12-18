using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class ExecuteViewModel : IExecute
    {
        private IExecute _characterMovement;
        private IExecute _grenade;
        private IExecute _mine;
        private ITakeExecute _takeObject;
        
        public ExecuteViewModel(List<IEnemyHurtViewModel> enemyDamageViewModel, CharacterModel character, IPull<IGrenadeModel> grenades, IPull<IMineModel> mines)
        {
            _characterMovement = new MovementInputViewModel(character);
            _takeObject = new TakeExecute(character, character.ThrowGrenadePosition);
            _grenade = new GrenadeExecute(enemyDamageViewModel, grenades, _takeObject.TakeObject, character.ThrowGrenadePosition);
            _mine = new MineExecute(mines, character.SetMinePosition);
        }

        public void Execute(float deltaTime)
        {
            _characterMovement.Execute(deltaTime);
            _grenade.Execute(deltaTime);
            _mine.Execute(deltaTime);
            _takeObject.Execute(deltaTime);
        }
    }
}