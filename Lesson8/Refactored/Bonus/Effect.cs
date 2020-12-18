using System;

namespace Unity4.Lesson8
{
    public class Effect : IEffect
    {
        private IPlayerModel _player;
        private ICharacterModel _character;

        public Effect(IPlayerModel player)
        {
            _player = player;
            _character = _player.Character.Copy();
        }

        public void SetEffect(IBonusModel bonus)
        {
            switch (bonus.EffectType)
            {
                case EffectType.None:
                    break;
                case EffectType.Speed:
                    _player.Character.Speed.MoveSpeed += bonus.Effect;
                    break;
                case EffectType.Health:
                    _player.Character.Health.CurrentHealth += bonus.Effect;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetEffect(EffectType type, float effect)
        {
            switch (type)
            {
                case EffectType.None:
                    break;
                case EffectType.Speed:
                    _player.Character.Speed.MoveSpeed += effect;
                    break;
                case EffectType.Health:
                    _player.Character.Health.CurrentHealth += effect;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }


        public void ReturnToDefault()
        {
            _player.Character.Speed.MoveSpeed = _character.Speed.MoveSpeed;
            _player.Character.Speed.RotationSpeed = _character.Speed.RotationSpeed;
        }
    }
}