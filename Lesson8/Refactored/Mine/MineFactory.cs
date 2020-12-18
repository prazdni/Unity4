﻿using UnityEngine;

namespace Unity4.Lesson8
{
    public class MineFactory : IFactory<MineConfiguration, IMineViewModel>
    {
        public IMineViewModel Create(MineConfiguration obj)
        {
            var mineTransform = Object.Instantiate(obj.Prefab, Vector3.zero, Quaternion.identity);
            var view = mineTransform.GetOrAddComponent<MineView>();

            IMineModel mineModel = new MineModel(mineTransform, obj.ExplosionForce, obj.ExplosionRadius, obj.Damage,
                obj.Duration);
            
            IMineViewModel mineViewModel = new MineViewModel(mineModel);
            
            view.Initialize(mineViewModel);

            return mineViewModel;
        }
    }
}