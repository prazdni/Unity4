namespace Unity4.Lesson8
{
    public interface IPlayerModel
    {
        ICharacterModel Character { get; }
        IPull<IExplosionViewModel<IGrenadeModel>> Grenades { get; }
        IPull<IExplosionViewModel<IMineModel>> Mines { get; }
    }
}