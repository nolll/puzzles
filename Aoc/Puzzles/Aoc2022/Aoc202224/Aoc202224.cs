using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

[Name("Blizzard Basin")]
public class Aoc202224 : AocPuzzle
{
    [Puzzle("2cfc10140c99d8efac8a77765769479d")]
    public int Part1(string input) => new BlizzardNavigation(input).Part1();

    [Puzzle("f055d2b6a8b11466406da741a5dd4b83")]
    public int Part2(string input) => new BlizzardNavigation(input).Part2();
}