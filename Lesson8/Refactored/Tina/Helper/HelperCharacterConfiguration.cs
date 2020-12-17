using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "HelperCharacter", menuName = "ScriptableObjects/HelperCharacter", order = 0)]
    public class HelperCharacterConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private BonusConfiguration _bonus;
        [SerializeField] private Vector3 _position;

        public Transform Prefab => _prefab;

        public BonusConfiguration Bonus => _bonus;

        public Vector3 Position => _position;
    }
}