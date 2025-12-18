using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202503;

[Name("Bush Salesman")]
public class FlipFlop202503 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var counts = new Dictionary<string, int>();
        foreach (var line in lines)
        {
            if (!counts.TryAdd(line, 1)) 
                counts[line]++;
        }

        var best2 = counts.MaxBy(o => o.Value).Key;
        
        return new PuzzleResult(best2);
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}