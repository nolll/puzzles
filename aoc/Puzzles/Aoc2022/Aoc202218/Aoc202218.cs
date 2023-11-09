using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202218;

public class Aoc202218 : AocPuzzle
{
    public override string Name => "Boiling Boulders";

    protected override PuzzleResult RunPart1()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(InputFile);

        return new PuzzleResult(result, "91235a24016ae0426b247e67bd3d3195");
    }

    protected override PuzzleResult RunPart2()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part2(InputFile);

        return new PuzzleResult(result, "40f35a686b6090010950fa3c11fb38ed");
    }
}