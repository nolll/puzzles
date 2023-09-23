using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day11;

public class Year2022Day11 : AocPuzzle
{
    public override string Name => "Monkey in the Middle";

    protected override PuzzleResult RunPart1()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part1(FileInput);

        return new PuzzleResult(result, 56350);
    }

    protected override PuzzleResult RunPart2()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part2(FileInput);

        return new PuzzleResult(result, 13_954_061_248);
    }
}