using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202402;

[Name("Red-Nosed Reports")]
public class Aoc202402 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var reports = ParseReports(input);
        var safeCount = reports.Count(IsSafe);
        return new PuzzleResult(safeCount, "d02b04efe3e126e637aa49339a13e490");
    }
    
    public PuzzleResult Part2(string input)
    {
        var reports = ParseReports(input);
        var safeCount = reports.Count(IsSafeWithDamping);
        return new PuzzleResult(safeCount, "913ea818784ae836ec632c9e92026a7b");
    }

    private static IEnumerable<List<int>> ParseReports(string input) => 
        input.Split(LineBreaks.Single).Select(o => o.Split(' ').Select(int.Parse).ToList());

    private static bool IsSafe(List<int> levels) => 
        IsSafeDecreasing(levels) || IsSafeDecreasing(levels.Reversed().ToList());

    private static bool IsSafeWithDamping(List<int> levels)
    {
        for (var i = 0; i < levels.Count; i++)
        {
            var current = levels.RemoveItemAt(i).ToList();
            
            if (IsSafe(current))
                return true;
        }
        
        return false;
    }

    private static bool IsSafeDecreasing(List<int> levels)
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
}