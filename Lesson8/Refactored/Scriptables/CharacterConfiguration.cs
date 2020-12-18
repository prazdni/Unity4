using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration", order = 0)]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private Transform _throwGrenadePosition;
        [SerializeField] private Transform _setMinePosition;
        [SerializeField] private HealthModel maxHealthModel;
        [SerializeField] private SpeedModel speedModel;
        [SerializeField] private float _takeRange;
        
        public Transform Prefab => _prefab;
        
        public Transform ThrowGrenadePosition => _throwGrenadePosition;
        
        public Transform SetMinePosition => _setMinePosition;

        public HealthModel HealthModel => maxHealthModel;

        public SpeedModel SpeedModel => speedModel;

        public float TakeRange => _takeRange;
    }
}