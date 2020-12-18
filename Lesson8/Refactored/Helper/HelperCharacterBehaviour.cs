using System;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class HelperCharacterBehaviour : IExecute
    {
        private IHelperCharacterModel _helper;
        private IPlayerModel _player;
        private IBonusThrow _bonusThrow;
        

        public HelperCharacterBehaviour(IHelperCharacterModel helper, IPlayerModel player, IOnPlayerEffect<IBonusModel> playerEffect)
        {
            _helper = helper;
            _player = player;
            _bonusThrow = new BonusThrow(player, helper.Bonus, _helper.Transform.position + Vector3.up, playerEffect);
        }

        public void Execute(float deltaTime)
        {
            if (Mathf.Approximately((_helper.Transform.position - _player.Character.Transform.position).sqrMagnitude,
                2.0f))
            {
                _bonusThrow.Throw();
            }
            
            _bonusThrow.Execute(deltaTime);
        }
    }
}