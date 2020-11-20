using UnityEngine;

namespace Asteroids
{
    public interface IFactory
    {
        Transform CreateInvisibleItem();
    }
}