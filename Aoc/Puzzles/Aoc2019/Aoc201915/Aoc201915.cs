using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

[Name("Oxygen System")]
public class Aoc201915 : AocPuzzle
{
    private Matrix<char> _map = new();

    protected override PuzzleResult RunPart1(string input)
    {
        var droid = new RepairDroid(input);
        var (result, map) = droid.Run();
        _map = map;

        return new PuzzleResult(result, "d20cf84c4da08d20e303bd7439d54765");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var filler = new OxygenFiller(_map);
        var result = filler.Fill();

        return new PuzzleResult(result, "d728ed642372031f836424a9f131f6f2");
    }
}