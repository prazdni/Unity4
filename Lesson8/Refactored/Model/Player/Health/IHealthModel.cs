namespace Unity4.Lesson8
{
    public interface IHealthModel
    {
        float MaxHealth { get; }
        float CurrentHealth { get; set; }
    }
}