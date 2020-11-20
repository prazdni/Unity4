using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class MagFactory : IUnitFactory
    {
        private readonly string _dataDirectory = "Data";
        private readonly string _dataFile = "UnitData.txt";
        private readonly JsonDataReader<UnitData> _reader;
        
        public MagFactory(JsonDataReader<UnitData> dataReader)
        {
            _reader = dataReader;
        }
        
        public Unit GetUnit(UnitType type)
        {
            var unitData = _reader.Load(Path.Combine(Path.Combine(Application.dataPath, _dataDirectory), _dataFile));
            var units = new List<Unit>();
            for (int i = 0; i < unitData.Count; i++)
            {
                units.Add(unitData[i].unit);
            }
            
            switch (type)
            {
                case UnitType.Infantry:
                    return units.FirstOrDefault(u => u.type ==  "mag");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}