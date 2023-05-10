using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2015.Day13;

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