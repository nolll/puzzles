using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day17;

public class Year2020Day17 : AocPuzzle
{
    public override string Name => "Conway Cubes";

    protected override PuzzleResult RunPart1()
    {
        var cube = new ConwayCube();
        var result = cube.Boot3D(FileInput, 6);
        return new PuzzleResult(result, 382);
    }

    protected override PuzzleResult RunPart2()
    {
        var cube = new ConwayCube();
        var result = cube.Boot4D(FileInput, 6);
        return new PuzzleResult(result, 2552);
    }
}