using UnityEngine;
using UnityEngine.Serialization;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 0)]
    public class Data : ScriptableObject
    {
        [SerializeField] private CharacterConfiguration _characterConfiguration;
        [SerializeField] private GrenadeConfiguration _grenadeConfiguration;
        [SerializeField] private MineConfiguration _mineConfiguration;
        [SerializeField] private BonusesConfiguration _bonusConfiguration;
        [SerializeField] private SimpleEnemyConfiguration _simpleEnemyConfiguration;
        [SerializeField] private ButtonConfiguration _buttonConfiguration;
        [SerializeField] private HelperCharacterConfiguration _helperCharacterConfiguration;

        public CharacterConfiguration CharacterConfiguration => _characterConfiguration;
        
        public GrenadeConfiguration GrenadeConfiguration => _grenadeConfiguration;
        
        public MineConfiguration MineConfiguration => _mineConfiguration;
        
        public BonusesConfiguration BonusesConfiguration => _bonusConfiguration;
        
        public SimpleEnemyConfiguration SimpleEnemyConfiguration => _simpleEnemyConfiguration;
        
        public ButtonConfiguration ButtonConfiguration => _buttonConfiguration;

        public HelperCharacterConfiguration HelperCharacterConfiguration => _helperCharacterConfiguration;
    }
}