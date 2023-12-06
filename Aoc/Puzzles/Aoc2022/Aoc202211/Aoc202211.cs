using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202211;

public class Aoc202211 : AocPuzzle
{
    public override string Name => "Monkey in the Middle";

    protected override PuzzleResult RunPart1()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part1(InputFile);

        return new PuzzleResult(result, "7d4be1aa43422b2344a6125943e730c4");
    }

    protected override PuzzleResult RunPart2()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part2(InputFile);

        return new PuzzleResult(result, "9b6edc59f2fbcf1491af28eecdb326fb");
    }
}