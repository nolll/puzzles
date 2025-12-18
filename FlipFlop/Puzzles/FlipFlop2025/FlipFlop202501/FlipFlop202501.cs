using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202501;

[Name("Dream Vacation")]
public class FlipFlop202501 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = lines.Select(o => o.Length / 2).Sum();
        return new PuzzleResult(sum);
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = lines.Select(o => o.Length / 2).Where(o => o % 2 == 0).Sum();
        return new PuzzleResult(sum);
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var sum = lines.Where(o => !o.Contains('e')).Select(o => o.Length / 2).Sum();
        return new PuzzleResult(sum);
    }
}