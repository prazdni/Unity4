using UnityEngine;

namespace Unity4.Lesson8
{
    [CreateAssetMenu(fileName = "GrenadeConfiguration", menuName = "ScriptableObjects", order = 0)]
    public class GrenadeConfiguration : ScriptableObject
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private float _throwForce;
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _damage;

        public Transform Prefab => _prefab;

        public float ThrowForce => _throwForce;
        
        public float ExplosionForce => _explosionForce;

        public float ExplosionRadius => _explosionRadius;
        
        public float Damage => _damage;
    }
}