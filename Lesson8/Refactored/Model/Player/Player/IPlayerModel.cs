namespace Unity4.Lesson8
{
    public interface IPlayerModel
    {
        ICharacterModel Character { get; }
        IGrenadeModel Grenade { get; }
        IMineModel Mine { get; }
    }
}