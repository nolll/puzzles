using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201814;

[Name("Chocolate Charts")]
public class Aoc201814 : AocPuzzle
{
    [Puzzle("0d4f97136a1cd3a6231512be77e5a06d")]
    public string Part1(string input) => new RecipeGenerator().ScoresAfter(int.Parse(input));

    [Puzzle("e266a7be3c46a5ed35b66710ecd16496")]
    public int Part2(string input) => new RecipeGenerator().RecipeCountBefore(input);
}