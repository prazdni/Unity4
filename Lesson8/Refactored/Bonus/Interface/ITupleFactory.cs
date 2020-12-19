namespace Unity4.Lesson8
{
    public interface ITupleFactory<T, I, J>
    {
        (I model, J viewModel) Create(T obj);
    }
}