namespace Unity4.Lesson8
{
    public interface ITakeExecute : IExecute
    {
        ITakeObject TakeObject { get; }
    }
}