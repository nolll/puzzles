using Pzl.Common;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202404;

[Name("")]
public class Codyssi202404 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var set = new HashSet<string>();
        foreach (var line in lines)
        {
            set.AddRange(line.Split(" <-> "));
        }
        return new PuzzleResult(set.Count, "48687e590201772c8544f0344efbceda");
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