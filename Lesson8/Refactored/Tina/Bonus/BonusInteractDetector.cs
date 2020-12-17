using System;

namespace Unity4.Lesson8
{
    public class BonusInteractDetector : IExecute
    {
        private IPlayerModel _player;
        private IBonusList _bonusList;
        private IOnPlayerEffect<IBonusModel> _playerEffect;
        
        public BonusInteractDetector(IPlayerModel player, IBonusList bonusList, IOnPlayerEffect<IBonusModel> playerEffect)
        {
            _player = player;
            _bonusList = bonusList;
            _playerEffect = playerEffect;
        }

        public void Execute(float deltaTime)
        {
            foreach (var bonus in _bonusList)
            {
                if ((_player.Character.Transform.position - bonus.Transform.position).sqrMagnitude < 1.0f &&
                    bonus.Transform.gameObject.activeSelf)
                {
                    _playerEffect.Effect(bonus);
                    _bonusList.OnInteract(bonus);
                }
            }
        }
    }
}