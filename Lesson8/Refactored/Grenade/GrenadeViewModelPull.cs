using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unity4.Lesson8
{
    public class GrenadeViewModelPull : IPull<IExplosionViewModel<IGrenadeModel>>
    {
        public int Count { get; }
        
        private List<IExplosionViewModel<IGrenadeModel>> _grenades;

        public GrenadeViewModelPull(IExplosionViewModel<IGrenadeModel> grenade, int count)
        {
            Count = count;
            _grenades = new List<IExplosionViewModel<IGrenadeModel>>();

            for (int i = 0; i < Count; i++)
            {
                _grenades.Add(grenade);
            }
        }
        
        public IExplosionViewModel<IGrenadeModel> Get()
        {
            return _grenades.FirstOrDefault(g => !g.DamageObj.Transform.gameObject.activeSelf);
        }

        public void Return(IExplosionViewModel<IGrenadeModel> obj)
        {
            obj.DamageObj.Transform.gameObject.SetActive(false);
        }
        
        public IEnumerator<IExplosionViewModel<IGrenadeModel>> GetEnumerator()
        {
            foreach (var grenade in _grenades)
            {
                yield return grenade;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}