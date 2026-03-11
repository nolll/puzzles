using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

[Name("Blizzard Basin")]
public class Aoc202224 : AocPuzzle
{
    [Puzzle("2cfc10140c99d8efac8a77765769479d")]
    public PuzzleResult Part1(string input)
    {
        var blizzardNavigation = new BlizzardNavigation(input);
        var result = blizzardNavigation.Part1();

        return new PuzzleResult(result);
    }

    [Puzzle("f055d2b6a8b11466406da741a5dd4b83")]
    public PuzzleResult Part2(string input)
    {
        var blizzardNavigation = new BlizzardNavigation(input);
        var result = blizzardNavigation.Part2();

        return new PuzzleResult(result);
    }
}