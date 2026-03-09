using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201817;

[Name("Reservoir Research")]
public class Aoc201817 : AocPuzzle
{
    [Puzzle("670e4fda6254e4ae79cdf1065fba7c51")]
    public int Part1(string input)
    {
        var filler = new ReservoirFiller(input);
        filler.Fill();
        return filler.TotalWaterTileCount;
    }

    [Puzzle("c188fe62ee29321d37a6c8cee549a1db")]
    public int Part2(string input)
    {
        var filler = new ReservoirFiller(input);
        filler.Fill();
        return filler.RetainedWaterTileCount;
    }
}