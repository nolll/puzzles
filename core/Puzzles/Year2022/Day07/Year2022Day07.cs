using Core.Platform;

namespace Core.Puzzles.Year2022.Day07;

public class Year2022Day07 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var fileSystem = new FileSystem();
        var result = fileSystem.Part1(FileInput);

        return new PuzzleResult(result, 1989474);
    }

    public override PuzzleResult RunPart2()
    {
        var fileSystem = new FileSystem();
        var result = fileSystem.Part2(FileInput);

        return new PuzzleResult(result, 1111607);
    }
}