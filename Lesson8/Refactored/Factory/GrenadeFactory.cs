using UnityEngine;

namespace Unity4.Lesson8
{
    public class GrenadeFactory : IFactory<GrenadeConfiguration, IGrenadeModel>
    {
        public IGrenadeModel Create(GrenadeConfiguration obj)
        {
            var grenadeTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            grenadeTransform.gameObject.SetActive(false);
            var view = grenadeTransform.GetOrAddComponent<GrenadeView>();

            IGrenadeModel grenadeModel = new GrenadeModel(grenadeTransform, obj.ThrowForce, obj.ExplosionForce,
                obj.ExplosionRadius, obj.Damage, obj.Duration);
            
            IExplosionViewModel grenadeViewModel = new GrenadeViewModel(grenadeModel);
            
            view.Initialize(grenadeViewModel);
            
            return grenadeModel;
        }
    }
}