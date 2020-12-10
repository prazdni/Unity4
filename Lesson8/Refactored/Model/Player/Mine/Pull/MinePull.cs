using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MinePull : IPullable
    {
        private List<Transform> _mines;
        
        public MinePull(MineConfiguration mine)
        {
            _mines = new List<Transform>(mine.Quantity)
            {
                Object.Instantiate(mine.Prefab, Vector3.zero, Quaternion.identity),
                Object.Instantiate(mine.Prefab, Vector3.zero, Quaternion.identity),
                Object.Instantiate(mine.Prefab, Vector3.zero, Quaternion.identity),
            };

            foreach (var m in _mines)
            {
                m.gameObject.SetActive(false);
            }
        }
        
        public Transform Get()
        {
            var mine = _mines.Find(a => !a.gameObject.activeSelf);
            if (mine == null)
            {
                var newMine = Object.Instantiate(mine, Vector3.zero, Quaternion.identity);
                newMine.gameObject.SetActive(false);
                _mines.Add(newMine);
            }

            return _mines.Find(a => !a.gameObject.activeSelf);
        }

        public void Return(Transform transform)
        {
            throw new System.NotImplementedException();
        }
    }
}