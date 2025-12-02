using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202502;

[Name("Gift Shop")]
public class Aoc202502 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, id => HasRepeatingPattern(id.ToString(), 2)), "149612f91b805f1c491e3263f1041be3");
    public PuzzleResult Part2(string input) => new(Solve(input, id => HasRepeatingPattern(id.ToString())), "3eaf1917c4c82033215760417a5a9131");

    private static long Solve(string input, Func<long, bool> hasRepeatingPattern)
    {
        var ranges = input.Split(',');
        var invalidIds = new List<long>();
        foreach (var range in ranges)
        {
            var (from, to) = range.Split('-').Select(long.Parse).ToArray();
            for (var id = from; id <= to; id++)
            {
                if(hasRepeatingPattern(id))
                    invalidIds.Add(id);
            }
        }
        
        return invalidIds.Sum();
    }

    private static bool HasRepeatingPattern(string id, int repeatCount)
    {
        if (id.Length % repeatCount != 0)
            return false;
        
        var patternLength = id.Length / repeatCount;
        if (id.Length % patternLength != 0)
            return false;
        
        var segments = new List<string>();
        for (var i = 0; i < id.Length / patternLength; i++)
        {
            segments.Add(id.Substring(i * patternLength, patternLength));
        }

        return segments.Distinct().Count() == 1;
    }
    
    private static bool HasRepeatingPattern(string id)
    {
        for (var repeats = 2; repeats <= id.Length; repeats++)
        {
            if (HasRepeatingPattern(id, repeats))
                return true;
        }

        return false;
    }
}