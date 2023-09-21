using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day07;

public class Year2021Day07 : AocPuzzle
{
    public override string Name => "The Treachery of Whales";

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