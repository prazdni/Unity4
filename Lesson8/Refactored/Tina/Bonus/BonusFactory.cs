namespace Unity4.Lesson8
{
    public class BonusFactory : IFactory<BonusConfiguration, BonusModel>
    {
        public BonusModel Create(BonusConfiguration obj)
        {
            return new BonusModel(obj);
        }
    }
}