namespace Unity4.Lesson8
{
    public interface IPlayerModel
    {
        ICharacterModel Character { get; }
        IPull<IGrenadeModel> Grenades { get; }
        IPull<IExplosionViewModel<>> Mines { get; }
    }
}