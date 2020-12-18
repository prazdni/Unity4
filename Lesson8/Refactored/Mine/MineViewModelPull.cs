using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class MineViewModelPull : IPull<IExplosionViewModel<IMineModel>>
    {
        public int Count { get; }
        
        private List<IExplosionViewModel<IMineModel>> _mines;

        public MineViewModelPull(IExplosionViewModel<IMineModel> mine, int count)
        {
            Count = count;
            
            _mines = new List<IExplosionViewModel<IMineModel>>();

            for (int i = 0; i < Count; i++)
            {
                _mines.Add(mine);
            }
        }
        public IExplosionViewModel<IMineModel> Get()
        {
            var count = _mines.FindAll(a => !a.DamageObj.Transform.gameObject.activeSelf).Count;
            
            if (count == Count)
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