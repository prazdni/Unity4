using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class MinePull : IMinePull
    {
        private List<IMineModel> _mines;
        private MineConfiguration _mineConfig;
        public int Count { get; }
        
        public MinePull(MineConfiguration mine)
        {
            Count = mine.Quantity;
            
            _mineConfig = mine;
            
            var mineModel = new MineModel(Object.Instantiate(mine.Prefab, Vector3.zero, Quaternion.identity),
                mine.ExplosionForce, mine.ExplosionRadius, mine.Damage);

            _mines = new List<IMineModel>();

            for (int i = 0; i < Count; i++)
            {
                _mines.Add(mineModel);
            }

            foreach (var m in _mines)
            {
                m.Transform.gameObject.SetActive(false);
            }
        }

        public IMineModel Get()
        {
            var mine = _mines.Find(a => !a.Transform.gameObject.activeSelf);
            
            if (mine == null)
            {
                var newMineModel = new MineModel(
                    Object.Instantiate(_mineConfig.Prefab, Vector3.zero, Quaternion.identity),
                    _mineConfig.ExplosionForce, _mineConfig.ExplosionRadius, _mineConfig.Damage);
                
                newMineModel.Transform.gameObject.SetActive(false);
                _mines.Add(newMineModel);
            }

            return _mines.Find(a => !a.Transform.gameObject.activeSelf);
        }
        
        public void Return(IMineModel mine)
        {
            mine.Transform.gameObject.SetActive(false);
        }
    }
}