using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201806;

[Name("Chronal Coordinates")]
public class Aoc201806 : AocPuzzle
{
    [Puzzle("38a2162984fb4f3ad26481fe9d035149")]
    public int Part1(string input) => new LargestAreaFinder(input).GetSizeOfLargestArea();

    [Puzzle("1272f4319b022610a3eb7f805e2fba48")]
    public int Part2(string input) => new LargestAreaFinder(input).GetSizeOfCentralArea(10000);
}