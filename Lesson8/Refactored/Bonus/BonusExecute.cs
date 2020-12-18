namespace Unity4.Lesson8
{
    public class BonusExecute : IExecute
    {
        private BonusBehaviour _bonusBehaviour;
        private BonusInteractDetector _bonusInteractDetector;
        
        public BonusExecute(IBonusList bonusList, IPlayerModel player, IOnPlayerEffect<IBonusModel> playerEffect)
        {
            _bonusBehaviour = new BonusBehaviour(bonusList);
            _bonusInteractDetector = new BonusInteractDetector(player, bonusList, playerEffect);
        }
        
        public void Execute(float deltaTime)
        {
            _bonusBehaviour.Execute(deltaTime);
            _bonusInteractDetector.Execute(deltaTime);
        }
    }
}