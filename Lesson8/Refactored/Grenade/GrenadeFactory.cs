using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeFactory : IFactory<GrenadeConfiguration, IExplosionViewModel<IGrenadeModel>>
    {
        public IExplosionViewModel<IGrenadeModel> Create(GrenadeConfiguration obj)
        {
            var grenadeTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            var view = grenadeTransform.GetOrAddComponent<GrenadeView>();

            IGrenadeModel grenadeModel = new GrenadeModel(grenadeTransform, obj.ThrowForce, obj.ExplosionForce,
                obj.ExplosionRadius, obj.Damage, obj.Duration);
            
            IExplosionViewModel<IGrenadeModel> grenadeViewModel = new GrenadeViewModel(grenadeModel);
            
            view.Initialize(grenadeViewModel);

            return grenadeViewModel;
        }
    }
}