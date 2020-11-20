using System;
using System.Collections.Generic;

namespace Asteroids
{
    [Serializable]
    class Wrapper<T>
    {
        public List<T> Items;
    }
}