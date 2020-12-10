using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "PickableItem", menuName = "ScriptableObjects/PickableItem", order = 0)]
    public class PickableItem : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
    }
}