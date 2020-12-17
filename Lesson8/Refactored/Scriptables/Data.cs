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
    }
}