using Core.Platform;

namespace Core.Puzzles.Year2020.Day09;

public class Year2020Day09 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var port = new XmasPort(FileInput, 25);
        var invalidNumber = port.FindFirstInvalidNumber();
        return new PuzzleResult(invalidNumber, 32321523);
    }

    public override PuzzleResult RunPart2()
    {
        var port = new XmasPort(FileInput, 25);
        var weakness = port.FindWeakness();
        return new PuzzleResult(weakness, 4794981);
    }
}