using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private PickableObjects _effect;

    public PickableObjects Effect
    {
        get => _effect;
    }
}
