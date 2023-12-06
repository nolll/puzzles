using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201814;

public class Aoc201814 : AocPuzzle
{
    public override string Name => "Chocolate Charts";

    protected override PuzzleResult RunPart1()
    {
        var generator = new RecipeGenerator();
        var scores = generator.ScoresAfter(Input);
        return new PuzzleResult(scores, "0d4f97136a1cd3a6231512be77e5a06d");
    }

    protected override PuzzleResult RunPart2()
    {
        var generator = new RecipeGenerator();
        var count = generator.RecipeCountBefore(Input.ToString());
        return new PuzzleResult(count, "e266a7be3c46a5ed35b66710ecd16496");
    }

    private const int Input = 306281;
}