using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineViewModel : IExecute
    {
        private IMineSetterViewModel _mineSetter;
        private IExecute _mineInput;
        
        public MineViewModel(MineModel mine, Transform setPoint)
        {
            _mineSetter = new MineSetterViewModel(mine, setPoint);
            _mineInput = new MineInputViewModel(_mineSetter);
        }

        public void Execute(float deltaTime)
        {
            _mineInput.Execute(deltaTime);
            _mineSetter.Execute(deltaTime);
        }
    }
}