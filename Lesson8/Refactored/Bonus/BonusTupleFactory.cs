﻿namespace Unity4.Lesson8
{
    public class BonusTupleFactory : ITupleFactory<,,>
    {
        public BonusModel Create(BonusConfiguration obj)
        {
            return new BonusModel(obj);
        }
    }
}