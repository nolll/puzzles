using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202508;

[Name("The Art of Connection")]
public class Ece202508 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Part1(input, 32), "13e1a785ec9325ce343a99dda7a6745f");

    public int Part1(string input, int nailCount)
    {
        var instructions = input.Split(',').Select(int.Parse).ToArray();
        return instructions.Zip(instructions.Skip(1)).Count(o => Math.Abs(o.Second - o.First) == nailCount / 2);
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