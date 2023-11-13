using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202201;

public class Aoc202201 : AocPuzzle
{
    public override string Name => "Calorie Counting";

    protected override PuzzleResult RunPart1()
    {
        var calorieCounts = new CalorieCounts(InputFile);
        return new PuzzleResult(calorieCounts.TopSum, "81d10392efffeffbb6e17e0d97cffb22");
    }

    protected override PuzzleResult RunPart2()
    {
        var calorieCounts = new CalorieCounts(InputFile);
        return new PuzzleResult(calorieCounts.Top3Sum, "f7b7d38797d430f1b611936533333c26");
    }
}