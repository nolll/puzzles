using System.Collections.Generic;
using System.Linq;

namespace Core.KnightsOfTheDinnerTable
{
    public class DinnerGuest
    {
        public string Name { get; }
        private IList<DinnerGuestRule> Rules { get; }
        
        public DinnerGuest(string name)
        {
            Name = name;
            Rules = new List<DinnerGuestRule>();
        }

        public void AddRule(DinnerGuestRule rule)
        {
            Rules.Add(rule);
        }

        public int GetHappiness(string otherName)
        {
            var rule = Rules.FirstOrDefault(o => o.Name == otherName);
            return rule?.Happiness ?? 0;
        }
    }
}