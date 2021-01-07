namespace Unity4.Lesson8
{
    public class ViewInitializer : IInitialize<IOnPlayerEffect<IBonusModel>>, IInitialize<IOnPlayerEffect<float>>, 
        IInitialize<IKeyViewModel>, IInitialize<IButtonViewModel>
    {
        private BonusView _bonusView;
        private ButtonView _buttonView;
        private HealthView _healthView;
        private KeyView _keyView;
        private EndGameView _endGameView;

        public ViewInitializer(BonusView bonusView, ButtonView buttonView, HealthView healthView, KeyView keyView,
            EndGameView endGameView)
        {
            _bonusView = bonusView;
            _buttonView = buttonView;
            _healthView = healthView;
            _keyView = keyView;
            _endGameView = endGameView;
        }

        public void Initialize(IOnPlayerEffect<IBonusModel> viewModel)
        {
            _bonusView.Initialize(viewModel);
        }

        public void Initialize(IOnPlayerEffect<float> viewModel)
        {
            _healthView.Initialize(viewModel);
            _endGameView.Initialize(viewModel);
        }

        public void Initialize(IKeyViewModel viewModel)
        {
            _keyView.Initialize(viewModel);
        }

        public void Initialize(IButtonViewModel viewModel)
        {
            _buttonView.Initialize(viewModel);
        }
    }
}