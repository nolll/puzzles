using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202218;

public class Year2022Day18 : AocPuzzle
{
    public override string Name => "Boiling Boulders";

    protected override PuzzleResult RunPart1()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(InputFile);

        return new PuzzleResult(result, 4444);
    }

    protected override PuzzleResult RunPart2()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part2(InputFile);

        return new PuzzleResult(result, 2530);
    }
}