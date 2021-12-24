using App.Platform;

namespace App.Puzzles.Year2021.Day24;

public class Year2021Day24 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var monad = new Monad(FileInput);
        var result = monad.FindLargestValidNumber();

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}