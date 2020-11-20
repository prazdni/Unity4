using UnityEngine;

namespace Lesson5.Decorator
{
    public class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerInstance;
        private readonly WeaponDefaultCharacteristics _defaultCharacteristics;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition,
            WeaponDefaultCharacteristics defaultCharacteristics)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
            _defaultCharacteristics = defaultCharacteristics;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerInstance = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override Weapon DeleteModification(Weapon weapon)
        {
            Object.Destroy(_mufflerInstance);
            _audioSource.volume = _defaultCharacteristics.Volume;
            weapon.SetAudioClip(_defaultCharacteristics.AudioClip);
            return weapon;
        }
    }
}