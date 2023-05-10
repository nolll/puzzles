using Aoc.Platform;

namespace Aoc.Puzzles.Year2022.Day07;

public class Year2022Day07 : Puzzle
{
    public override string Title => "No Space Left On Device";

    public override PuzzleResult RunPart1()
    {
        var fileSystem = new FileSystem(FileInput);
        var result = fileSystem.Part1();

        return new PuzzleResult(result, 1989474);
    }

    public override PuzzleResult RunPart2()
    {
        var fileSystem = new FileSystem(FileInput);
        var result = fileSystem.Part2();

        return new PuzzleResult(result, 1111607);
    }
}