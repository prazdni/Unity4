using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4.Lesson8
{
    public class BonusList : IBonusList
    {
        private List<IBonusModel> _bonuses;

        public BonusList(BonusesConfiguration bonusesConfiguration)
        {
            var factory = new BonusFactory();
            _bonuses = new List<IBonusModel>();

            for (int i = 0; i < bonusesConfiguration.Bonuses.Count; i++)
            {
                var bonus = factory.Create(bonusesConfiguration.Bonuses[i]);
                _bonuses.Add(bonus);
            }
        }

        public void OnInteract(IBonusModel bonus)
        {
            bonus.Transform.gameObject.SetActive(false);
        }

        public IEnumerator<IBonusModel> GetEnumerator()
        {
            foreach (var bonus in _bonuses)
            {
                yield return bonus;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}