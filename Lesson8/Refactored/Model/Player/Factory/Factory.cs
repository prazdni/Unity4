using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public class Factory : 
        IFactory<GrenadeConfiguration, IGrenadeModel>, 
        IFactory<MineConfiguration, IMineModel>, 
        IFactory<CharacterConfiguration, ICharacterModel>, 
        IPlayerFactory, 
        IFactory<SimpleEnemyConfiguration, IEnemyViewModel>,
        IFactory<SimpleEnemyConfiguration, List<IEnemyViewModel>>
    {
        private IFactory<GrenadeConfiguration, IGrenadeModel> _grenadeFactory;
        private IFactory<MineConfiguration, IMineModel> _mineFactory;
        private IFactory<CharacterConfiguration, ICharacterModel> _characterFactory;
        private IFactory<SimpleEnemyConfiguration, IEnemyViewModel> _enemyFactory;
        private IFactory<SimpleEnemyConfiguration, List<IEnemyViewModel>> _enemiesFactory;
        private IPlayerFactory _playerFactory;

        public Factory()
        {
            _grenadeFactory = new GrenadeFactory();
            _mineFactory = new MineFactory();
            _characterFactory = new CharacterFactory();
            _playerFactory = new PlayerFactory();
            _enemyFactory = new SimpleEnemyFactory();
        }
        
        public IGrenadeModel Create(GrenadeConfiguration obj)
        {
            return _grenadeFactory.Create(obj);
        }

        public IMineModel Create(MineConfiguration obj)
        {
            return _mineFactory.Create(obj);
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

        List<IEnemyViewModel> IFactory<SimpleEnemyConfiguration, List<IEnemyViewModel>>.Create(SimpleEnemyConfiguration obj)
        {
            List<IEnemyViewModel> enemies = new List<IEnemyViewModel>();
            
            for (int i = 0; i < obj.Quantity; i++)
            {
                enemies.Add(_enemyFactory.Create(obj));
            }

            return enemies;
        }
    }
}