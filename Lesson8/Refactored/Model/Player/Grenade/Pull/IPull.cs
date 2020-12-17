namespace Unity4.Lesson8
{
    public interface IPull<T>
    {
        int Count { get; }
        T Get();
        void Return(T grenade);
    }
}