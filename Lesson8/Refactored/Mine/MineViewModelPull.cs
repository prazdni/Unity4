using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class MineViewModelPull : IPull<IExplosionViewModel<IMineModel>>
    {
        private List<IExplosionViewModel<IMineModel>> _mines;
        public int Count => _mines.FindAll(a => !a.DamageObj.Transform.gameObject.activeSelf).Count;

        private int _maxCount;
        
        public MineViewModelPull(MineConfiguration obj)
        {
            _maxCount = obj.Quantity;
            _mines = new List<IExplosionViewModel<IMineModel>>();
            
            var mineFactory = new MineFactory();

            for (int i = 0; i < Count; i++)
            {
                _mines.Add(mineFactory.Create(obj));
            }
        }
        public IExplosionViewModel<IMineModel> Get()
        {
            if (Count <= _maxCount)
            {
                return _mines.Find(a => !a.DamageObj.Transform.gameObject.activeSelf);
            }
                
            _mines[0].DamageObj.Transform.gameObject.SetActive(false);
            return _mines[0];
        }

        public void Return(IExplosionViewModel<IMineModel> obj)
        {
            obj.DamageObj.Transform.gameObject.SetActive(false);
        }
        
        public IEnumerator<IExplosionViewModel<IMineModel>> GetEnumerator()
        {
            foreach (var mine in _mines)
            {
                yield return mine;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}