using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201515;

public class Aoc201515 : AocPuzzle
{
    public override string Name => "Science for Hungry People";

    protected override PuzzleResult RunPart1()
    {
        var bakery = new CookieBakery(InputFile);
        return new PuzzleResult(bakery.HighestScore, "f40d60cbbeb6aff8eff639104c438ab2");
    }

    protected override PuzzleResult RunPart2()
    {
        var bakery = new CookieBakery(InputFile);
        return new PuzzleResult(bakery.HighestScoreWith500Calories, "b617905d91fbff24a49282c5ea2ec636");
    }
}