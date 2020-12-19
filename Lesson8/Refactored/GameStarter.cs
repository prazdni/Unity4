﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        [SerializeField] private BonusView _bonusView;
        [SerializeField] private ButtonView _buttonView;
        [SerializeField] private HealthView _healthView;
        
        private Factory _factory;
        
        private void Start()
        {
            _factory = new Factory();

            var characterModel = _factory.Create(_data.CharacterConfiguration);

            var grenade = _factory.Create(_data.GrenadeConfiguration);
            var grenadePull = new GrenadeModelPull(grenade.model);
            
            var mine = _factory.Create(_data.MineConfiguration);
            var minePull = new MineModelPull(mine.model);

            var player = _factory.Create(characterModel, grenadePull, minePull);
            _healthView.Initialize(new HealthViewModel(player.Character.HealthModel));

            var bonusEffectViewModel = new BonusEffectViewModel(player);
            _bonusView.Initialize(bonusEffectViewModel);
            _buttonView.Initialize(new ButtonViewModel(new ButtonModel(_data.ButtonConfiguration)));

            List<IEnemyViewModel> enemies = new List<IEnemyViewModel>();
            for (int i = 0; i < _data.SimpleEnemyConfiguration.Quantity; i++)
            {
                enemies.Add(_factory.Create(_data.SimpleEnemyConfiguration));
            }
            var enemyExecute = new SimpleEnemyExecute(enemies);
            
            var playerExecute = new PlayerInputExecute(player);
        }
    }
}