using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202105;

[Name("Hydrothermal Venture")]
public class Aoc202105 : AocPuzzle
{
    [Puzzle("72e2846f2036e57e75a10d9d0b5a99ad")]
    public int Part1(string input) => new VentsMap().Run(input, true);

    [Puzzle("e07b568228a7ed5a9bc9276d343e6973")]
    public int Part2(string input) => new VentsMap().Run(input, false);
}