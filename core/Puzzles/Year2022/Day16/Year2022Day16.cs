using Core.Platform;

namespace Core.Puzzles.Year2022.Day16;

public class Year2022Day16 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var pipes = new Year2022Day16Tests.VolcanicPipes();
        var result = pipes.Part1(FileInput);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}