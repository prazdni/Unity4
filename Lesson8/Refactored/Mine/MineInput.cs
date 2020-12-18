using Asteroids;

namespace Unity4.Lesson8
{
    public class MineInput : IExecute
    {
        private IMineSetter _mineSetter;
        private IUserKeyInput _mineInput;


        public MineInput(IMineSetter mineSetter)
        {
            _mineSetter = mineSetter;
            _mineInput = new PCUserInputMine();
        }
        
        public void Execute(float deltaTime)
        {
            if (_mineInput.IsKeyUp())
            {
                _mineSetter.Set();
            }
        }
    }
}