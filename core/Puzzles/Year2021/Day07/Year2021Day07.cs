using Core.Platform;

namespace Core.Puzzles.Year2021.Day07;

public class Year2021Day07 : Puzzle
{
    public override string Title => "The Treachery of Whales";

    public override PuzzleResult RunPart1()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(FileInput, false);
        return new PuzzleResult(result, 344535);
    }

    public override PuzzleResult RunPart2()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(FileInput, true);
        return new PuzzleResult(result, 95581659);
    }
}