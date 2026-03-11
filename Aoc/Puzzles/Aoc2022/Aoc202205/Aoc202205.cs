using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202205;

[Name("Supply Stacks")]
public class Aoc202205 : AocPuzzle
{
    [Puzzle("9828a1b1c82b8879448ee5d92f6245f8")]
    public string? Part1(string input)
    {
        var crane = new CargoCrane(input);
        crane.Run1();
        return crane.Message;
    }

    [Puzzle("be487b7be9543b1de622347458714dcd")]
    public string? Part2(string input)
    {
        var crane = new CargoCrane(input);
        crane.Run2();
        return crane.Message;
    }
}