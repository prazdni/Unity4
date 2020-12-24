﻿namespace Unity4.Lesson8
{
    public class BonusFactory : IFactory<BonusConfiguration, IBonusModel>
    {
        public IBonusModel Create(BonusConfiguration obj)
        {
            return new BonusModel(obj);
        }
    }
}