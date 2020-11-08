using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public EnemyType TypeOfEnemy;
        public Health EnemyHealth;
    }
}