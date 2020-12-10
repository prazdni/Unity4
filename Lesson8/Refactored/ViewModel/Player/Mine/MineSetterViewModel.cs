using Asteroids;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineSetterViewModel : IMineSetterViewModel
    {
        private Transform _setPoint;
        private UpTimer _timer;
        private bool _isMineSet;
        private IExplosionViewModel _explosion;
        public MineSetterViewModel(MineModel mine, Transform setPoint)
        {
            _setPoint = setPoint;
            _timer = new UpTimer();
            _isMineSet = false;
            _explosion = new ExplosionViewModel(mine.ExplosionForce, mine.ExplosionRadius, mine.Damage);
        }
        
        public void Set()
        {
            throw new System.NotImplementedException();
        }

        public void Execute(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}