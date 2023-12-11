using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202201;

[Name("Calorie Counting")]
public class Aoc202201(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var calorieCounts = new CalorieCounts(input);
        return new PuzzleResult(calorieCounts.TopSum, "81d10392efffeffbb6e17e0d97cffb22");
    }

    protected override PuzzleResult RunPart2()
    {
        var calorieCounts = new CalorieCounts(input);
        return new PuzzleResult(calorieCounts.Top3Sum, "f7b7d38797d430f1b611936533333c26");
    }
}