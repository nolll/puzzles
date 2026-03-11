using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202014;

[Name("Docking Data")]
public class Aoc202014 : AocPuzzle
{
    [Puzzle("df6ceb0c5b8153992f5246f19ad4d827")]
    public long Part1(string input) => new BitmaskSystem1().Run(input);

    [Puzzle("578a4ca2408035c16e799f4662a58823")]
    public long Part2(string input) => new BitmaskSystem2().Run(input);
}