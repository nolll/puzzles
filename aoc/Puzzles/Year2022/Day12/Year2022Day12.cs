using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day12;

public class Year2022Day12 : AocPuzzle
{
    public override string Name => "Hill Climbing Algorithm";

    protected override PuzzleResult RunPart1()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part1(FileInput);

        return new PuzzleResult(result, 352);
    }

    protected override PuzzleResult RunPart2()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part2(FileInput);

        return new PuzzleResult(result, 345);
    }
}