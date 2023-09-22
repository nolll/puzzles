using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day13;

public class Year2015Day13 : AocPuzzle
{
    public override string Name => "Knights of the Dinner Table";

    protected override PuzzleResult RunPart1()
    {
        var table = new DinnerTable(FileInput);
        return new PuzzleResult(table.HappinessChange, 618);
    }

    protected override PuzzleResult RunPart2()
    {
        var table = new DinnerTable(FileInput, true);
        return new PuzzleResult(table.HappinessChange, 601);
    }
}