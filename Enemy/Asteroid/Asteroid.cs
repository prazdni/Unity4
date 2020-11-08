using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        public Asteroid(EnemyCharacteristics enemyCharacteristics, Health health) : 
            base(enemyCharacteristics, health)
        {
            
        }
    }
}