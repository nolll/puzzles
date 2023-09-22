using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day14;

public class Year2018Day14 : AocPuzzle
{
    public override string Name => "Chocolate Charts";

    protected override PuzzleResult RunPart1()
    {
        var generator = new RecipeGenerator();
        var scores = generator.ScoresAfter(Input);
        return new PuzzleResult(scores, "3718110721");
    }

    protected override PuzzleResult RunPart2()
    {
        var generator = new RecipeGenerator();
        var count = generator.RecipeCountBefore(Input.ToString());
        return new PuzzleResult(count, 20_298_300);
    }

    private const int Input = 306281;
}