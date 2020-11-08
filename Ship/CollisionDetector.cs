using System;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionDetector : MonoBehaviour
    {
        private Health _health;

        private void Start()
        {
            _health = new Health(100);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.ApplyDamage(10.0f);
        }
    }
}