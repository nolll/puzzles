using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201517;

[Name("No Such Thing as Too Much")]
public class Aoc201517 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var container = new EggnogContainers(input);
        var combinations = container.GetCombinations(150);
        return new PuzzleResult(combinations.Count, "5c9cb3225ec72026a92a9d18b0257800");
    }

    public PuzzleResult RunPart2(string input)
    {
        var container = new EggnogContainers(input);
        var combinations = container.GetCombinationsWithLeastContainers(150);
        return new PuzzleResult(combinations.Count, "b5099aa249856738b5000cb46145f473");
    }
}