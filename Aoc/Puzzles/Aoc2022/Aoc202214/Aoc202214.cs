using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202214;

[Name("Regolith Reservoir")]
public class Aoc202214 : AocPuzzle
{
    [Puzzle("8772ddaaa456233ff5c9888ae72de902")]
    public PuzzleResult Part1(string input)
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part1(input);

        return new PuzzleResult(result);
    }

    [Puzzle("a4ec5b539a3242d500f793c91d89e0d8")]
    public PuzzleResult Part2(string input)
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part2(input);

        return new PuzzleResult(result);
    }
}