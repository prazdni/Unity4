using System;
using UnityEngine;

namespace Unity4.Lesson6
{
    public class MessageBroker
    {
        public void OnDestroyObject(Transform box)
        {
            Debug.Log(box.gameObject.name + " was destroyed!");
        }
    }
}