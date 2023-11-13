using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201707;

public class Aoc201707 : AocPuzzle
{
    public override string Name => "Recursive Circus";

    protected override PuzzleResult RunPart1()
    {
        var towers = new RecursiveTowers(InputFile);
        return new PuzzleResult(towers.BottomName, "7005dac413613feef76e5931331aac39");
    }

    protected override PuzzleResult RunPart2()
    {
        var towers = new RecursiveTowers(InputFile);
        return new PuzzleResult(towers.AdjustedWeight, "a431cfa493227f90dd341325e0c8992b");
    }
}