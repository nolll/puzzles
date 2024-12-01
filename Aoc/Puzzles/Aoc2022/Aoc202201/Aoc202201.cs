using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202201;

[Name("Calorie Counting")]
public class Aoc202201 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var calorieCounts = new CalorieCounts(input);
        return new PuzzleResult(calorieCounts.TopSum, "81d10392efffeffbb6e17e0d97cffb22");
    }

    public PuzzleResult RunPart2(string input)
    {
        var calorieCounts = new CalorieCounts(input);
        return new PuzzleResult(calorieCounts.Top3Sum, "f7b7d38797d430f1b611936533333c26");
    }
}