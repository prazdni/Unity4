namespace Unity4.Lesson8
{
    public class ExecuteViewModel : IExecute
    {
        private IExecute _characterMovement;
        private IExecute _grenade;
        private IExecute _mine;
        private ITakeExecute _takeObject;
        
        public ExecuteViewModel(CharacterModel character, GrenadeModel grenade, MineModel mine)
        {
            _characterMovement = new MovementInputViewModel(character);
            _takeObject = new TakeExecute(character, character.ThrowGrenadePosition);
            _grenade = new GrenadeViewModel(grenade, _takeObject.TakeObject, character.ThrowGrenadePosition);
            _mine = new MineViewModel(mine, character.SetMinePosition);
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