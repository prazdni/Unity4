using UnityEngine;

namespace Unity4.Lesson8
{
    public class HelperCharacterModel : IHelperCharacterModel
    {
        public Transform Transform { get; }
        public IBonusModel Bonus { get; }

        public HelperCharacterModel(HelperCharacterConfiguration helper)
        {
            Transform = Object.Instantiate(helper.Prefab);
            Bonus = new BonusModel(helper.Bonus);
        }
    }
}