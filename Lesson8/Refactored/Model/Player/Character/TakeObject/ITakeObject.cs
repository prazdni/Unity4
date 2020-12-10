namespace Unity4.Lesson8
{
    public interface ITakeObject : IExecute
    {
        void Take();
        bool IsObjectTaken { get; }
    }
}