using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

[Name("Oxygen System")]
public class Aoc201915 : AocPuzzle
{
    [Puzzle("d20cf84c4da08d20e303bd7439d54765")]
    public int Part1(string input)
    {
        var (result, _) = new RepairDroid(input).Run();
        return result;
    }

    [Puzzle("d728ed642372031f836424a9f131f6f2")]
    public int Part2(string input)
    {
        var (_, map) = new RepairDroid(input).Run();
        return new OxygenFiller(map).Fill();
    }
}