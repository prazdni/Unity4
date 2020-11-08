using UnityEngine;

namespace Asteroids
{
    public interface IFactory
    {
        Transform CreateInvisibleBullet();
    }
}