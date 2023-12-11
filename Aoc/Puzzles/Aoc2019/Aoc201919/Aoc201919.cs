using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201919;

[Name("Tractor Beam")]
public class Aoc201919(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var tbc = new TractorBeamComputer1(Input, 50, 50);
        var result = tbc.GetPullCount();

        return new PuzzleResult(result, "984c01d5977631fa8cd48a8fbd689c1c");
    }

    protected override PuzzleResult RunPart2()
    {
        var tbc = new TractorBeamComputer2(Input, 50, 50);
        var result = tbc.Find100By100Square();

        return new PuzzleResult(result.Checksum, "c22eb8f92f96b6e515142cffa3b161c0");
    }
}