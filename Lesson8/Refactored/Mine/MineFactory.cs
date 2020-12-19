using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineFactory : IFactory<MineConfiguration, IMineModel>
    {
        public IMineModel Create(MineConfiguration obj)
        {
            var mineTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            var view = mineTransform.GetOrAddComponent<MineView>();

            IMineModel mineModel = new MineModel(mineTransform, obj.ExplosionForce, obj.ExplosionRadius, obj.Damage,
                obj.Duration);
            
            IExplosionViewModel mineViewModel = new MineViewModel(mineModel);
            
            view.Initialize(mineViewModel);

            return mineModel;
        }
    }
}