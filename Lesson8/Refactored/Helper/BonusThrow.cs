using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusThrow : IBonusThrow
    {
        private IPlayerModel _player;
        private IOnPlayerEffect<IBonusModel> _playerEffect;
        private IPull<IBonusModel> _bonusThrowPull;
        private IBonusModel _bonus;
        
        private bool _isBonusFlying;
        
        public BonusThrow(IPlayerModel playerModel, IBonusModel bonusModel, Vector3 position, IOnPlayerEffect<IBonusModel> playerEffect)
        {
            _playerEffect = playerEffect;
            _player = playerModel;
            _bonusThrowPull = new BonusThrowPull(bonusModel, position);
        }
        
        public void Execute(float deltaTime)
        {
            if (_isBonusFlying)
            {
                if (Mathf.Approximately((_player.Character.Transform.position - _bonus.Transform.position).sqrMagnitude, 0.01f))
                {
                    OnPlayerHit();
                }
                else
                {
                    OnPlayerGo(deltaTime);
                }
            }
        }

        public void Throw()
        {
            _bonus = _bonusThrowPull.Get();
            _isBonusFlying = true;
        }

        private void OnPlayerHit()
        {
            _playerEffect.Effect(_bonus);
            _isBonusFlying = false;
            _bonusThrowPull.Return(_bonus);
        }

        private void OnPlayerGo(float deltaTime)
        {
            _bonus.Transform.position += Vector3.forward * deltaTime;
            _bonus.Transform.LookAt(_player.Character.Transform.position);
        }
    }
}