using System.Collections.Generic;

namespace Unity4.Lesson8
{
    public interface IBonusList : IEnumerable<IBonusModel>
    {
        void OnInteract(IBonusModel bonus);
    }
}