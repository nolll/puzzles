using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201814;

[Name("Chocolate Charts")]
public class Aoc201814 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var generator = new RecipeGenerator();
        var scores = generator.ScoresAfter(int.Parse(input));
        return new PuzzleResult(scores, "0d4f97136a1cd3a6231512be77e5a06d");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var generator = new RecipeGenerator();
        var count = generator.RecipeCountBefore(input);
        return new PuzzleResult(count, "e266a7be3c46a5ed35b66710ecd16496");
    }
}