using UnityEngine;

namespace Unity4.Lesson8
{
    public class PlayerModel : IPlayerModel
    {
        public ICharacterModel Character { get; }
        public IPull Grenades { get; }
        public IMinePull Mines { get; }
        
        public PlayerModel(ICharacterModel character, IPull grenades, IMinePull mines)
        {
            Character = character;
            Grenades = grenades;
            Mines = mines;
        }
    }
}