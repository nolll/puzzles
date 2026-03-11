using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202207;

[Name("No Space Left On Device")]
public class Aoc202207 : AocPuzzle
{
    [Puzzle("4f30884d94a8463608dcc378747e00f7")]
    public long Part1(string input) => new FileSystem(input).Part1();

    [Puzzle("e619d2b3e6e0cf1c93c956785cb6e527")]
    public long Part2(string input) => new FileSystem(input).Part2();
}