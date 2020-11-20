using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    public class UnitFactory : IUnitFactory
    {
        private IUnitFactory _infantryFactory;
        private IUnitFactory _magFactory;

        public UnitFactory()
        {
            JsonDataReader<UnitData> dataReader = new JsonDataReader<UnitData>();
            _infantryFactory = new InfantryFactory(dataReader);
            _magFactory = new MagFactory(dataReader);
        }

        public Unit GetUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Mag:
                    return _magFactory.GetUnit(type);
                case UnitType.Infantry:
                    return _infantryFactory.GetUnit(type);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}