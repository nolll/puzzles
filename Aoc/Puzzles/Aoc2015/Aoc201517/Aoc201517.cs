using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201517;

[Name("No Such Thing as Too Much")]
public class Aoc201517(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var container = new EggnogContainers(Input);
        var combinations = container.GetCombinations(150);
        return new PuzzleResult(combinations.Count, "5c9cb3225ec72026a92a9d18b0257800");
    }

    protected override PuzzleResult RunPart2()
    {
        var container = new EggnogContainers(Input);
        var combinations = container.GetCombinationsWithLeastContainers(150);
        return new PuzzleResult(combinations.Count, "b5099aa249856738b5000cb46145f473");
    }
}