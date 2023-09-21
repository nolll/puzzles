using Aoc.Platform;
using common.CoordinateSystems.CoordinateSystem2D;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day15;

public class Year2019Day15 : AocPuzzle
{
    private Matrix<char> _map;
    public override string Name => "Oxygen System";

    public override PuzzleResult RunPart1()
    {
        var droid = new RepairDroid(FileInput);
        var (result, map) = droid.Run();
        _map = map;

        return new PuzzleResult(result, 424);
    }

    public override PuzzleResult RunPart2()
    {
        var filler = new OxygenFiller(_map);
        var result = filler.Fill();

        return new PuzzleResult(result, 446);
    }
}