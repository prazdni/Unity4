namespace Unity4.Lesson8
{
    public interface IInitialize<T>
    {
        void Initialize(T viewModel);
    }
}