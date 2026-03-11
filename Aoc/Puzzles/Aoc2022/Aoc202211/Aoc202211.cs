using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202211;

[Name("Monkey in the Middle")]
public class Aoc202211 : AocPuzzle
{
    [Puzzle("7d4be1aa43422b2344a6125943e730c4")]
    public long Part1(string input) => new MonkeyBusiness().Part1(input);

    [Puzzle("9b6edc59f2fbcf1491af28eecdb326fb")]
    public long Part2(string input) => new MonkeyBusiness().Part2(input);
}