using Core.Platform;

namespace Core.Puzzles.Year2022.Day16;

public class Year2022Day16 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var pipes = new VolcanicPipes();
        var result = pipes.Part1(FileInput);

        // Max if all is open all the time is 6930
        // Guess 673, too low
        // Guess 1209, too low
        // Guess 2059, too low
        // Guess 2186, wrong
        // Guess 4244, wrong

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}