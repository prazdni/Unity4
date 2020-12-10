using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration", order = 0)]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private Transform _throwGrenadePosition;
        [SerializeField] private Transform _setMinePosition;
        [SerializeField] private Health _maxHealth;
        [SerializeField] private Speed _speed;
        [SerializeField] private float _takeRange;
        
        public Transform Prefab => _prefab;
        
        public Transform ThrowGrenadePosition => _throwGrenadePosition;
        
        public Transform SetMinePosition => _setMinePosition;

        public Health Health => _maxHealth;

        public Speed Speed => _speed;

        public float TakeRange => _takeRange;
    }
}