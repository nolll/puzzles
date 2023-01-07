using Core.Platform;

namespace Core.Puzzles.Year2017.Day12;

public class Year2017Day12 : Puzzle
{
    public override string Title => "Digital Plumber";

    public override PuzzleResult RunPart1()
    {
        var pipes = new Pipes(FileInput);
        return new PuzzleResult(pipes.PipesInGroupZero, 145);
    }

    public override PuzzleResult RunPart2()
    {
        var pipes = new Pipes(FileInput);
        return new PuzzleResult(pipes.GroupCount, 207);
    }
}