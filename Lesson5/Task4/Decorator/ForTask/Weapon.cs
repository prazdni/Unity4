using UnityEngine;

namespace Lesson5.Decorator
{
    public class Weapon : IFire
    {
        private Transform _barrelPosition;
        private IAmmunition _bullet;
        private float _volume;
        private float _force;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;
        public WeaponDefaultCharacteristics WeaponDefaultCharacteristics { get; }

        public Weapon(IAmmunition bullet, Transform barrelPosition, float force, float volume, AudioSource audioSource,
            AudioClip audioClip)
        {
            _bullet = bullet;
            _barrelPosition = barrelPosition;

            WeaponDefaultCharacteristics = new WeaponDefaultCharacteristics(force, volume, audioClip, audioSource);

            _force = force;
            _volume = volume;
            _audioSource = audioSource;
            _audioClip = audioClip;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPosition = barrelPosition;
        }

        public void SetBullet(IAmmunition bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }
        
        public void Fire()
        {
            var bullet = Object.Instantiate(_bullet.BulletInstance, _barrelPosition.position, Quaternion.identity);
            bullet.AddForce(_barrelPosition.forward * _force);
            Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}