using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202211;

[Name("Monkey in the Middle")]
public class Aoc202211 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part1(input);

        return new PuzzleResult(result, "7d4be1aa43422b2344a6125943e730c4");
    }

    public PuzzleResult RunPart2(string input)
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part2(input);

        return new PuzzleResult(result, "9b6edc59f2fbcf1491af28eecdb326fb");
    }
}