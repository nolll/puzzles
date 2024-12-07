using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202407;

[Name("")]
public class Aoc202407 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = 0L;
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var target = long.Parse(parts[0]);
            var units = parts[1].Split(' ').Select(long.Parse).ToArray();

            var combinations = GetCombinations(units.Skip(1).ToList(), units.First());
            if (combinations.Any(o => o == target))
                sum += target;
        }
        
        return new PuzzleResult(sum, "d8627e3b777340dd66a65a22e6ea7e85");
    }

    private List<long> GetCombinations(List<long> units, long v)
    {
        if (units.Count == 0)
            return [v];

        var nextList = units.Skip(1).ToList();
        var nextItem = units.First();
        var results = new List<long>();
        results.AddRange(GetCombinations(nextList, v + nextItem));
        results.AddRange(GetCombinations(nextList, v * nextItem));
        return results;
    }
    
    private List<long> GetCombinations2(List<long> units, long v)
    {
        if (units.Count == 0)
            return [v];

        var nextList = units.Skip(1).ToList();
        var nextItem = units.First();
        var results = new List<long>();
        results.AddRange(GetCombinations2(nextList, v + nextItem));
        results.AddRange(GetCombinations2(nextList, v * nextItem));
        results.AddRange(GetCombinations2(nextList, long.Parse($"{v}{nextItem}")));
        return results;
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = 0L;
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var target = long.Parse(parts[0]);
            var units = parts[1].Split(' ').Select(long.Parse).ToArray();

            var combinations = GetCombinations2(units.Skip(1).ToList(), units.First());
            if (combinations.Any(o => o == target))
                sum += target;
        }
        
        return new PuzzleResult(sum, "caf0656b286d7fb0cfa38222a516fc08");
    }
}