using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201625;

[Name("Clock Signal")]
public class Aoc201625 : AocPuzzle
{
    [Puzzle("5523923bd52d76e1c1d68b1cfdff95b5")]
    public int Part1(string input) => new ClockSignalGenerator().LowestA;
}