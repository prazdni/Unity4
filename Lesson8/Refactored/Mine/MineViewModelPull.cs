using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class MineViewModelPull : IPull<IMineViewModel>
    {
        private List<IMineViewModel> _mines;
        public int Count { get; }

        public MineViewModelPull(MineConfiguration obj)
        {
            Count = obj.Quantity;
            
            var mineFactory = new MineFactory();

            for (int i = 0; i < Count; i++)
            {
                _mines.Add(mineFactory.Create(obj));
            }
        }
        public IMineViewModel Get()
        {
            throw new System.NotImplementedException();
        }

        public void Return(IMineViewModel grenade)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerator<IMineViewModel> GetEnumerator()
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