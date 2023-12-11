using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201814;

[Name("Chocolate Charts")]
public class Aoc201814(string input) : AocPuzzle
{
    private int IntInput => int.Parse(input);

    protected override PuzzleResult RunPart1()
    {
        var generator = new RecipeGenerator();
        var scores = generator.ScoresAfter(IntInput);
        return new PuzzleResult(scores, "0d4f97136a1cd3a6231512be77e5a06d");
    }

    protected override PuzzleResult RunPart2()
    {
        var generator = new RecipeGenerator();
        var count = generator.RecipeCountBefore(input);
        return new PuzzleResult(count, "e266a7be3c46a5ed35b66710ecd16496");
    }
}