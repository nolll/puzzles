using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202014;

[Name("Docking Data")]
public class Aoc202014(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var system = new BitmaskSystem1();
        var sum = system.Run(Input);
        return new PuzzleResult(sum, "df6ceb0c5b8153992f5246f19ad4d827");
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new BitmaskSystem2();
        var sum = system.Run(Input);
        return new PuzzleResult(sum, "578a4ca2408035c16e799f4662a58823");
    }
}