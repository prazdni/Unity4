using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unity4.Lesson8
{
    public class GrenadeModelPull : IPull<IGrenadeModel>
    {
        public int Count => _grenades.FindAll(a => !a.Transform.gameObject.activeSelf).Count;
        
        private List<IGrenadeModel> _grenades;

        public GrenadeModelPull(IGrenadeModel grenade)
        {
            _grenades = new List<IGrenadeModel>();

            for (int i = 0; i < Count; i++)
            {
                _grenades.Add(grenade);
            }
        }
        
        public IGrenadeModel Get()
        {
            return _grenades.FirstOrDefault(g => !g.Transform.gameObject.activeSelf);
        }

        public void Return(IGrenadeModel obj)
        {
            obj.Transform.gameObject.SetActive(false);
        }
        
        public IEnumerator<IGrenadeModel> GetEnumerator()
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