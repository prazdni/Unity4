namespace Unity4.Lesson8
{
    public class PlayerInputExecute : IExecute
    {
        private IExecute _characterInput;
        private IExecute _takeInput;
        private IExecute _grenadeInput;
        private IExecute _mineInput;
        
        public PlayerInputExecute(IPlayerModel player)
        {
            _characterInput = new MovementInput(player.Character);
            _mineInput = new MineInput(player.Mines, player.Character.SetMinePosition);
            
            var takeObject = new TakeObject(player.Character.ThrowGrenadePosition, player.Character.TakeRange);
            _takeInput = new TakeObjectInput(takeObject);
            _grenadeInput = new GrenadeInput(player.Grenades, player.Character.ThrowGrenadePosition, takeObject);
        }

        public void Execute(float deltaTime)
        {
            _characterInput.Execute(deltaTime);
            _mineInput.Execute(deltaTime);
            _takeInput.Execute(deltaTime);
            _grenadeInput.Execute(deltaTime);
        }
    }
}