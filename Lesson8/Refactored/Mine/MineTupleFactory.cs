using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineTupleFactory : ITupleFactory<MineConfiguration, IMineModel, IExplosionViewModel<IMineModel>>
    {
        public (IMineModel model, IExplosionViewModel<IMineModel> viewModel) Create(MineConfiguration obj)
        {
            var mineTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            var view = mineTransform.GetOrAddComponent<MineView>();

            IMineModel mineModel = new MineModel(mineTransform, obj.ExplosionForce, obj.ExplosionRadius, obj.Damage,
                obj.Duration);
            
            IExplosionViewModel<IMineModel> mineViewModel = new MineViewModel(mineModel);
            
            view.Initialize(mineViewModel);

            return (mineModel, mineViewModel);
        }
    }
}