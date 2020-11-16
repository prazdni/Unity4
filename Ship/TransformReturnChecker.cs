using UnityEngine;

namespace Asteroids
{
    public class TransformReturnChecker : IReturnable
    {
        private Camera _camera;
        
        public TransformReturnChecker()
        {
            _camera = Camera.main;
        }
        public virtual bool ShouldReturn(Transform sceneObject)
        {
            var shouldReturn = false;
            
            var vec = _camera.WorldToViewportPoint(sceneObject.position);
            
            if (vec.x < 0 || vec.x > 1 || vec.y < 0 || vec.y > 1)
            {
                shouldReturn = true;
            }

            return shouldReturn;
        }
    }
}