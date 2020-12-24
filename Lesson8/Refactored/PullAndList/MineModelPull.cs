using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class MineModelPull : IPull<IMineModel>
    {
        public int Count => _mines.FindAll(a => !a.Transform.gameObject.activeSelf).Count;
        
        private List<IMineModel> _mines;

        public MineModelPull(IMineModel mine)
        {
            _mines = new List<IMineModel>();

            for (int i = 0; i < Count; i++)
            {
                _mines.Add(mine);
            }
        }
        public IMineModel Get()
        {
            if (Count == 0)
            {
                return _mines.Find(a => !a.Transform.gameObject.activeSelf);
            }
                
            _mines[0].Transform.gameObject.SetActive(false);
            return _mines[0];
        }

        public void Return(IMineModel obj)
        {
            obj.Transform.gameObject.SetActive(false);
        }
        
        public IEnumerator<IMineModel> GetEnumerator()
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