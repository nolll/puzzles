using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202218;

[Name("Boiling Boulders")]
public class Aoc202218(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(input);

        return new PuzzleResult(result, "91235a24016ae0426b247e67bd3d3195");
    }

    protected override PuzzleResult RunPart2()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part2(input);

        return new PuzzleResult(result, "40f35a686b6090010950fa3c11fb38ed");
    }
}