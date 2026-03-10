using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

[Name("Oxygen System")]
public class Aoc201915 : AocPuzzle
{
    private Grid<char> _map = new();

    [Puzzle("d20cf84c4da08d20e303bd7439d54765")]
    public PuzzleResult Part1(string input)
    {
        var droid = new RepairDroid(input);
        var (result, map) = droid.Run();
        _map = map;

        return new PuzzleResult(result);
    }

    [Puzzle("d728ed642372031f836424a9f131f6f2")]
    public PuzzleResult Part2(string input)
    {
        var filler = new OxygenFiller(_map);
        var result = filler.Fill();

        return new PuzzleResult(result);
    }
}