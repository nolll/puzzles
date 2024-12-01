using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202014;

[Name("Docking Data")]
public class Aoc202014 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var system = new BitmaskSystem1();
        var sum = system.Run(input);
        return new PuzzleResult(sum, "df6ceb0c5b8153992f5246f19ad4d827");
    }

    public PuzzleResult RunPart2(string input)
    {
        var system = new BitmaskSystem2();
        var sum = system.Run(input);
        return new PuzzleResult(sum, "578a4ca2408035c16e799f4662a58823");
    }
}