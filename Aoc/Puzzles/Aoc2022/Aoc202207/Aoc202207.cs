using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202207;

[Name("No Space Left On Device")]
public class Aoc202207 : AocPuzzle
{
    [Puzzle("4f30884d94a8463608dcc378747e00f7")]
    public PuzzleResult Part1(string input)
    {
        var fileSystem = new FileSystem(input);
        var result = fileSystem.Part1();

        return new PuzzleResult(result);
    }

    [Puzzle("e619d2b3e6e0cf1c93c956785cb6e527")]
    public PuzzleResult Part2(string input)
    {
        var fileSystem = new FileSystem(input);
        var result = fileSystem.Part2();

        return new PuzzleResult(result);
    }
}