using UnityEngine;

namespace Asteroids
{
    public class MoveManager : IExecute
    {
        private IShip _ship;
        
        private IUserAxisInput _horizontal;
        private IUserAxisInput _vertical;

        public MoveManager(IShip ship)
        {
            _ship = ship;
            
            _horizontal = new PCUserAxisInputHorizontal();
            _vertical = new PCUserAxisInputVertical();
        }


        public void Execute(float deltaTime)
        {
            _ship.Move(_horizontal.GetAxis(), _vertical.GetAxis(), deltaTime);
        }
    }
}