using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202014;

[Name("Docking Data")]
public class Aoc202014 : AocPuzzle
{
    [Puzzle("df6ceb0c5b8153992f5246f19ad4d827")]
    public PuzzleResult Part1(string input)
    {
        var system = new BitmaskSystem1();
        var sum = system.Run(input);
        return new PuzzleResult(sum);
    }

    [Puzzle("578a4ca2408035c16e799f4662a58823")]
    public PuzzleResult Part2(string input)
    {
        var system = new BitmaskSystem2();
        var sum = system.Run(input);
        return new PuzzleResult(sum);
    }
}