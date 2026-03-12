using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202125;

[Name("Sea Cucumber")]
public class Aoc202125 : AocPuzzle
{
    [Puzzle("b2c5d4f507c64adf10e3434888f5c9a9")]
    public int Part1(string input) => new HerdOfSeaCucumbers(input).MoveUntilStop();
}