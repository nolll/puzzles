using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day07;

public class Year2022Day07 : AocPuzzle
{
    public override string Name => "No Space Left On Device";

    protected override PuzzleResult RunPart1()
    {
        var fileSystem = new FileSystem(FileInput);
        var result = fileSystem.Part1();

        return new PuzzleResult(result, 1989474);
    }

    protected override PuzzleResult RunPart2()
    {
        var fileSystem = new FileSystem(FileInput);
        var result = fileSystem.Part2();

        return new PuzzleResult(result, 1111607);
    }
}