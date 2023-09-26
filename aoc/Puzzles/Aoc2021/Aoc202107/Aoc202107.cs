using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202107;

public class Aoc202107 : AocPuzzle
{
    public override string Name => "The Treachery of Whales";

    protected override PuzzleResult RunPart1()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(InputFile, false);
        return new PuzzleResult(result, 344535);
    }

    protected override PuzzleResult RunPart2()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(InputFile, true);
        return new PuzzleResult(result, 95581659);
    }
}