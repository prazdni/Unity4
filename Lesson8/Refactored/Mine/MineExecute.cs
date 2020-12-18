using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineExecute : IExecute
    {
        private IMineSetter _mineSetter;
        private IExecute _mineInput;
        
        public MineExecute(IPull<IMineModel> mines, Transform setPoint)
        {
            _mineSetter = new MineDamage(mines, setPoint);
            _mineInput = new MineInput(_mineSetter);
        }

        public void Execute(float deltaTime)
        {
            _mineInput.Execute(deltaTime);
            _mineSetter.Execute(deltaTime);
        }
    }
}