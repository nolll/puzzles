using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202205;

[Name("Supply Stacks")]
public class Aoc202205 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var crane = new CargoCrane(input);
        crane.Run1();
        return new PuzzleResult(crane.Message, "9828a1b1c82b8879448ee5d92f6245f8");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var crane = new CargoCrane(input);
        crane.Run2();
        return new PuzzleResult(crane.Message, "be487b7be9543b1de622347458714dcd");
    }
}