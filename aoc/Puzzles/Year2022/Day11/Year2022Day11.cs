using Aoc.Platform;

namespace Aoc.Puzzles.Year2022.Day11;

public class Year2022Day11 : Puzzle
{
    public override string Title => "Monkey in the Middle";

    public override PuzzleResult RunPart1()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part1(FileInput);

        return new PuzzleResult(result, 56350);
    }

    public override PuzzleResult RunPart2()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Part2(FileInput);

        return new PuzzleResult(result, 13_954_061_248);
    }
}