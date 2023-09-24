using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day15;

public class Year2019Day15 : AocPuzzle
{
    private Matrix<char> _map = new();
    public override string Name => "Oxygen System";

    protected override PuzzleResult RunPart1()
    {
        var droid = new RepairDroid(InputFile);
        var (result, map) = droid.Run();
        _map = map;

        return new PuzzleResult(result, 424);
    }

    protected override PuzzleResult RunPart2()
    {
        var filler = new OxygenFiller(_map);
        var result = filler.Fill();

        return new PuzzleResult(result, 446);
    }
}