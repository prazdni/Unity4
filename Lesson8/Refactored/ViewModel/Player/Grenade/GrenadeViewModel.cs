using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeViewModel : IExecute
    {
        private IGrenadeThrower _grenadeThrower;
        private IExecute _grenadeInput;
        
        public GrenadeViewModel(GrenadeModel grenade, ITakeObject takeObject, Transform throwPoint)
        {
            _grenadeThrower = new GrenadeThrowViewModel(grenade, takeObject, throwPoint);
            _grenadeInput = new GrenadeInputViewModel(_grenadeThrower);
        }
        
        public void Execute(float deltaTime)
        {
            _grenadeInput.Execute(deltaTime);
            _grenadeThrower.Execute(deltaTime);
        }
    }
}