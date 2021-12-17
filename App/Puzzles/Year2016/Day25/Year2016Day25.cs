using App.Platform;

namespace App.Puzzles.Year2016.Day25;

public class Year2016Day25 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var generator = new ClockSignalGenerator();
        return new PuzzleResult(generator.LowestA, 198);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}