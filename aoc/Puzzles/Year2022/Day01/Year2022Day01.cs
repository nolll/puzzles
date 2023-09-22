using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day01;

public class Year2022Day01 : AocPuzzle
{
    public override string Name => "Calorie Counting";

    protected override PuzzleResult RunPart1()
    {
        var calorieCounts = new CalorieCounts(FileInput);
        return new PuzzleResult(calorieCounts.TopSum, 71023);
    }

    protected override PuzzleResult RunPart2()
    {
        var calorieCounts = new CalorieCounts(FileInput);
        return new PuzzleResult(calorieCounts.Top3Sum, 206289);
    }
}