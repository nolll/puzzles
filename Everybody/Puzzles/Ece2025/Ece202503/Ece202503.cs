using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202503;

[Name("The Deepest Fit")]
public class Ece202503 : EverybodyEventPuzzle
{
    [Puzzle("834923ed61b6cffb158275b579f37e6d")]
    public PuzzleResult Part1(string input)
    {
        var sum = Numbers.IntsFromString(input).Distinct().Sum();
        
        return new PuzzleResult(sum);
    }

    [Puzzle("7a8f8d408f4dcba2fa43a58f9593634b")]
    public PuzzleResult Part2(string input)
    {
        var sum = Numbers.IntsFromString(input).Distinct().Order().Take(20).Sum();
        
        return new PuzzleResult(sum);
    }

    [Puzzle("886e38a454bf82b4535da9e9b9889379")]
    public PuzzleResult Part3(string input)
    {
        var setCount = Numbers.IntsFromString(input).GroupBy(o => o).Select(o => o.Count()).Max();
        
        return new PuzzleResult(setCount);
    }
}