using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using NaughtyAttributes;

namespace Unity4.Lesson5
{
    /*
     * Нашёл на просторах интернета интересную обёртку. Правда, при такой реализации нельзя добавлять новые элементы из
     * инспектора, а только изменять.
     */
    public class FirstTaskExample : MonoBehaviour
    {
        public SerialisedStringIntDictionary SerializedDictionary = new SerialisedStringIntDictionary()
        {
            {"I", 1}
        };
    }
}