using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201905;

[Name("Sunny with a Chance of Asteroids")]
public class Aoc201905 : AocPuzzle
{
    private long _output;

    [Puzzle("fb635501f54f36e602ebf7e465625fba")]
    public long Part1(string input)
    {
        var ci1 = new IntCodeComputer(input, ReadInputPart1, WriteOutput);
        ci1.Start();

        return _output;
    }

    [Puzzle("35062337f01f4ea95b2e1f10c739b629")]
    public long Part2(string input)
    {
        var ci2 = new IntCodeComputer(input, ReadInputPart2, WriteOutput);
        ci2.Start();

        return _output;
    }

    private static long ReadInputPart1() => 1;
    private static long ReadInputPart2() => 5;

    private bool WriteOutput(long output)
    {
        _output = output;
        return true;
    }
}