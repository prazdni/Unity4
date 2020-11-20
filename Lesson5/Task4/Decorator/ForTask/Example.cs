﻿using System;
using UnityEngine;

namespace Lesson5.Decorator
{
    public class Example : MonoBehaviour
    {
        private IFire _fire;

        [Header("Start Gun")] 
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, 10.0f, _audioSource, _audioClip);
            
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler,
                _barrelPositionMuffler.position, weapon.WeaponDefaultCharacteristics);
            modificationWeapon.ApplyModification(weapon);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}