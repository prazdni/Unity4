namespace Unity4.Lesson8
{
    public interface IFactory<T, I>
    {
        I Create(T obj);
    }
}