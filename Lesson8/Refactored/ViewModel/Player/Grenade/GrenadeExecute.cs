using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeExecute : IExecute
    {
        private IGrenadeThrower _grenadeThrower;
        private IExecute _grenadeInput;
        
        public GrenadeExecute(IPull grenades, ITakeObject takeObject, Transform throwPoint)
        {
            _grenadeThrower = new GrenadeThrow(grenades, takeObject, throwPoint);
            _grenadeInput = new GrenadeInput(_grenadeThrower);
        }
        
        public void Execute(float deltaTime)
        {
            _grenadeInput.Execute(deltaTime);
            _grenadeThrower.Execute(deltaTime);
        }
    }
}