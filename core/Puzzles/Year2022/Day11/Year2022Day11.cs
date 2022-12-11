using Core.Platform;

namespace Core.Puzzles.Year2022.Day11;

public class Year2022Day11 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Run(FileInput, true, 20);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        var monkeyBusiness = new MonkeyBusiness();
        var result = monkeyBusiness.Run(FileInput, false, 10_000);

        return new PuzzleResult(result);
    }
}