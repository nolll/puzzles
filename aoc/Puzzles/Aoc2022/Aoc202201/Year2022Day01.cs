using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202201;

public class Year2022Day01 : AocPuzzle
{
    public override string Name => "Calorie Counting";

    protected override PuzzleResult RunPart1()
    {
        var calorieCounts = new CalorieCounts(InputFile);
        return new PuzzleResult(calorieCounts.TopSum, 71023);
    }

    protected override PuzzleResult RunPart2()
    {
        var calorieCounts = new CalorieCounts(InputFile);
        return new PuzzleResult(calorieCounts.Top3Sum, 206289);
    }
}