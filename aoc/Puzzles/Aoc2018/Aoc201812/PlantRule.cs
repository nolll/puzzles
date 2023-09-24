using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2018.Aoc201812;

public class PlantRule
{
    public bool[] Pattern { get; }
    public bool Result { get; }

    public PlantRule(string s)
    {
        var parts = s.Split(" => ");
        Pattern = parts[0].ToCharArray().Select(IsTrue).ToArray();
        Result = IsTrue(parts[1].First());
    }

    private bool IsTrue(char c)
    {
        return c == '#';
    }

    public bool IsMatch(List<bool> current)
    {
        return !current.Where((t, i) => t != Pattern[i]).Any();
    }
}