using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201515;

public class Year2015Day15 : AocPuzzle
{
    public override string Name => "Science for Hungry People";

    protected override PuzzleResult RunPart1()
    {
        var bakery = new CookieBakery(InputFile);
        return new PuzzleResult(bakery.HighestScore, 21_367_368);
    }

    protected override PuzzleResult RunPart2()
    {
        var bakery = new CookieBakery(InputFile);
        return new PuzzleResult(bakery.HighestScoreWith500Calories, 1_766_400);
    }
}