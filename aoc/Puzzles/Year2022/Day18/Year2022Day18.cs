using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day18;

public class Year2022Day18 : AocPuzzle
{
    public override string Name => "Boiling Boulders";

    public override PuzzleResult RunPart1()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(FileInput);

        return new PuzzleResult(result, 4444);
    }

    public override PuzzleResult RunPart2()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part2(FileInput);

        return new PuzzleResult(result, 2530);
    }
}