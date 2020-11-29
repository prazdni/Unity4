using UnityEngine;

namespace Asteroids
{
    public abstract class EnemyInfoUI : MonoBehaviour
    {
        public abstract void ShowInfo(EnemyEventInfo info);
    }
}