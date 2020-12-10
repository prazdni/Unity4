using Asteroids;

namespace Unity4.Lesson8
{
    public class MineInputViewModel : IExecute
    {
        private IMineSetterViewModel _mineSetter;
        private IUserKeyInput _mineInput;


        public MineInputViewModel(IMineSetterViewModel mineSetter)
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