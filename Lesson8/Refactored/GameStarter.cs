using System;
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
        [SerializeField] private KeyView _keyView;
        [SerializeField] private EndGameView _endGameView;
        
        private ViewInitializer _viewInitializer;
        private BonusExecute _bonusExecute;
        private IExecute _helperExecute;
        private IExecute _enemyExecute;
        private IExecute _playerExecute;
        
        private void Start()
        {
            var factory = new Factory();
            _viewInitializer = new ViewInitializer(_bonusView ,_buttonView, _healthView, _keyView, _endGameView);

            var player = factory.Create(factory.Create(_data.CharacterConfiguration),
                new GrenadeModelPull(factory.Create(_data.GrenadeConfiguration)),
                new MineModelPull(factory.Create(_data.MineConfiguration)));
            
            _viewInitializer.Initialize(new HealthViewModel(player.Character.HealthModel));

            var bonusEffectViewModel = new BonusEffectViewModel(player);
            _viewInitializer.Initialize(new BonusEffectViewModel(player));
            
            _viewInitializer.Initialize(new ButtonViewModel(new ButtonModel(_data.ButtonConfiguration)));
            _viewInitializer.Initialize(new KeyViewModel(new KeyModel(_data.KeyConfiguration)));
            
            _bonusExecute = new BonusExecute(new BonusList(_data.BonusesConfiguration), player, bonusEffectViewModel);

            _helperExecute =
                new HelperCharacterExecute(new HelperCharacterModel(_data.HelperCharacterConfiguration), player,
                    bonusEffectViewModel);

            var enemies =
                ((IFactory<SimpleEnemyConfiguration, List<IEnemyViewModel>>) factory).Create(
                    _data.SimpleEnemyConfiguration);
            
            _enemyExecute = new SimpleEnemyExecute(enemies);
            
            _playerExecute = new PlayerInputExecute(player);
        }

        private void Update()
        {
            _bonusExecute.Execute(Time.deltaTime);
            _helperExecute.Execute(Time.deltaTime);
            _enemyExecute.Execute(Time.deltaTime);
            _playerExecute.Execute(Time.deltaTime);
        }
    }
}