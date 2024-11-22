using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

[Name("Blizzard Basin")]
public class Aoc202224(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var blizzardNavigation = new BlizzardNavigation(input);
        var result = blizzardNavigation.Part1();

        return new PuzzleResult(result, "2cfc10140c99d8efac8a77765769479d");
    }

    protected override PuzzleResult RunPart2()
    {
        var blizzardNavigation = new BlizzardNavigation(input);
        var result = blizzardNavigation.Part2();

        return new PuzzleResult(result, "f055d2b6a8b11466406da741a5dd4b83");
    }
}