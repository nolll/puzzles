using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day17;

public class Year2015Day17 : AocPuzzle
{
    public override string Title => "No Such Thing as Too Much";

    public override PuzzleResult RunPart1()
    {
        var container = new EggnogContainers(FileInput);
        var combinations = container.GetCombinations(150);
        return new PuzzleResult(combinations.Count, 1304);
    }

    public override PuzzleResult RunPart2()
    {
        var container = new EggnogContainers(FileInput);
        var combinations = container.GetCombinationsWithLeastContainers(150);
        return new PuzzleResult(combinations.Count, 18);
    }
}