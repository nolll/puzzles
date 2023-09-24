using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201517;

public class Aoc201517 : AocPuzzle
{
    public override string Name => "No Such Thing as Too Much";

    protected override PuzzleResult RunPart1()
    {
        var container = new EggnogContainers(InputFile);
        var combinations = container.GetCombinations(150);
        return new PuzzleResult(combinations.Count, 1304);
    }

    protected override PuzzleResult RunPart2()
    {
        var container = new EggnogContainers(InputFile);
        var combinations = container.GetCombinationsWithLeastContainers(150);
        return new PuzzleResult(combinations.Count, 18);
    }
}