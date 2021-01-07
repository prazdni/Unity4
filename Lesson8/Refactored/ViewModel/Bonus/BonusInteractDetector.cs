using System;

namespace Unity4.Lesson8
{
    public class BonusInteractDetector : IExecute
    {
        private IPlayerModel _player;
        private IBonusList _bonusList;
        private BonusEffectViewModel _playerEffect;
        
        public BonusInteractDetector(IPlayerModel player, IBonusList bonusList, BonusEffectViewModel playerEffect)
        {
            _player = player;
            _bonusList = bonusList;
            _playerEffect = playerEffect;
        }

        public void Execute(float deltaTime)
        {
            foreach (var bonus in _bonusList)
            {
                if ((_player.Character.Transform.position - bonus.Transform.position).sqrMagnitude < 0.1f &&
                    bonus.Transform.gameObject.activeSelf)
                {
                    _playerEffect.Effect(bonus);
                    _bonusList.OnInteract(bonus);
                }
            }
            
            _playerEffect.Execute(deltaTime);
        }
    }
}