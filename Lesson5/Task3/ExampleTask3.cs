using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    public class ExampleTask3 : MonoBehaviour
    {
        private void Start()
        {
            IUnitFactory unitFactory = new UnitFactory();
            print(unitFactory.GetUnit(UnitType.Infantry).type);
        }
    }
}