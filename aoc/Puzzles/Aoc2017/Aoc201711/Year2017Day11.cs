using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201711;

public class Year2017Day11 : AocPuzzle
{
    public override string Name => "Hex Ed";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new HexGridNavigator(InputFile);
        return new PuzzleResult(navigator.EndDistance, 808);
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new HexGridNavigator(InputFile);
        return new PuzzleResult(navigator.MaxDistance, 1556);
    }
}