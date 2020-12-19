namespace Unity4.Lesson8
{
    public interface IPlayerFactory
    {
        IPlayerModel Create(ICharacterModel character, IPull<IGrenadeModel> grenadePull, IPull<IMineModel> minePull);
    }
}