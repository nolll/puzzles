using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202207;

public class Year2022Day07 : AocPuzzle
{
    public override string Name => "No Space Left On Device";

    protected override PuzzleResult RunPart1()
    {
        var fileSystem = new FileSystem(InputFile);
        var result = fileSystem.Part1();

        return new PuzzleResult(result, 1989474);
    }

    protected override PuzzleResult RunPart2()
    {
        var fileSystem = new FileSystem(InputFile);
        var result = fileSystem.Part2();

        return new PuzzleResult(result, 1111607);
    }
}