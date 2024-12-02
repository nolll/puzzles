using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202402;

[Name("")]
public class Aoc202402 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var reports = input.Split(LineBreaks.Single).Select(o => o.Split(' ').Select(int.Parse).ToArray());
        var safeCount = reports.Count(IsSafe);
        return new PuzzleResult(safeCount, "d02b04efe3e126e637aa49339a13e490");
    }

    private static bool IsSafe(int[] levels)
    {
        return IsSafeDecreasing(levels) || IsSafeIncreasing(levels);
    }

    private static bool IsSafeDecreasing(int[] levels)
    {
        var lastLevel = levels.First();
        foreach (var level in levels.Skip(1))
        {
            if (lastLevel <= level || Math.Abs(lastLevel - level) > 3)
                return false;

            lastLevel = level;
        }
        
        return true;
    }
    
    private static bool IsSafeIncreasing(int[] levels)
    {
        var lastLevel = levels.First();
        foreach (var level in levels.Skip(1))
        {
            if (lastLevel >= level || Math.Abs(lastLevel - level) > 3)
                return false;
            
            lastLevel = level;
        }
        
        return true;
    }
}