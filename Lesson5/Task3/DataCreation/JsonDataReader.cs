using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    public class JsonDataReader<T>
    {
        public List<T> Load(string path = null)
        {
            var str = File.ReadAllText(path);
            Wrapper<T> items = JsonUtility.FromJson<Wrapper<T>>(str);
            return items.Items;
        }
    }
}