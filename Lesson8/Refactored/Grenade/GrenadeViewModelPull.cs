using System.Collections;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class GrenadeViewModelPull : IPull<IExplosionViewModel<IGrenadeModel>>
    {
        public int Count { get; }
        
        private List<IExplosionViewModel<IGrenadeModel>> _grenades;

        public GrenadeViewModelPull()
        {
            _grenades = new List<IExplosionViewModel<IGrenadeModel>>();
            
        }
        
        public IExplosionViewModel<IGrenadeModel> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Return(IExplosionViewModel<IGrenadeModel> obj)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerator<IExplosionViewModel<IGrenadeModel>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}