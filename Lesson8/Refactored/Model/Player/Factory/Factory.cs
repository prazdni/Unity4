namespace Unity4.Lesson8
{
    public class Factory : ITupleFactory, IFactory<CharacterConfiguration, ICharacterModel>, IPlayerFactory, 
        IFactory<SimpleEnemyConfiguration, IEnemyViewModel>
    {
        private ITupleFactory<GrenadeConfiguration, IGrenadeModel, IExplosionViewModel> _grenadeTupleFactory;
        private ITupleFactory<MineConfiguration, IMineModel, IExplosionViewModel> _mineTupleFactory;
        private IFactory<CharacterConfiguration, ICharacterModel> _characterFactory;
        private IFactory<SimpleEnemyConfiguration, IEnemyViewModel> _enemyFactory;
        private IPlayerFactory _playerFactory;

        public Factory()
        {
            _grenadeTupleFactory = new GrenadeTupleFactory();
            _mineTupleFactory = new MineTupleFactory();
            _characterFactory = new CharacterFactory();
            _playerFactory = new PlayerFactory();
            _enemyFactory = new SimpleEnemyFactory();
        }
        
        public (IGrenadeModel model, IExplosionViewModel viewModel) Create(GrenadeConfiguration obj)
        {
            return _grenadeTupleFactory.Create(obj);
        }

        public (IMineModel model, IExplosionViewModel viewModel) Create(MineConfiguration obj)
        {
            return _mineTupleFactory.Create(obj);
        }
        
        public ICharacterModel Create(CharacterConfiguration obj)
        {
            return _characterFactory.Create(obj);
        }
        
        public IPlayerModel Create(ICharacterModel character, IPull<IGrenadeModel> grenadePull, IPull<IMineModel> minePull)
        {
            return _playerFactory.Create(character, grenadePull, minePull);
        }

        public IEnemyViewModel Create(SimpleEnemyConfiguration obj)
        {
            return _enemyFactory.Create(obj);
        }
    }
}