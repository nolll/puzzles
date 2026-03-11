using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201919;

[Name("Tractor Beam")]
public class Aoc201919 : AocPuzzle
{
    [Puzzle("984c01d5977631fa8cd48a8fbd689c1c")]
    public int Part1(string input) => new TractorBeamComputer1(input, 50, 50).GetPullCount();

    [Puzzle("c22eb8f92f96b6e515142cffa3b161c0")]
    public int Part2(string input) => new TractorBeamComputer2(input, 50, 50).Find100By100Square().Checksum;
}