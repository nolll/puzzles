using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day17;

public class Year2020Day17 : AocPuzzle
{
    public override string Title => "Conway Cubes";

    public override PuzzleResult RunPart1()
    {
        var cube = new ConwayCube();
        var result = cube.Boot3D(FileInput, 6);
        return new PuzzleResult(result, 382);
    }

    public override PuzzleResult RunPart2()
    {
        var cube = new ConwayCube();
        var result = cube.Boot4D(FileInput, 6);
        return new PuzzleResult(result, 2552);
    }
}