using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineInput : IExecute
    {
        private IMineSetter _mineSetter;
        private IUserKeyInput _mineInput;

        public MineInput(IPull<IExplosionViewModel<IMineModel>> mines, Transform setPoint)
        {
            _mineSetter = new MineSetter(mines, setPoint);
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