using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201523;

[Name("Opening the Turing Lock")]
public class Aoc201523 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var computer1 = new ChristmasComputer();
        computer1.Run(input);
        return new PuzzleResult(computer1.RegisterB, "33adfc1e185fd4bc7ea824d0c6a24aa0");
    }

    public PuzzleResult Part2(string input)
    {
        var computer = new ChristmasComputer();
        computer.Run(input, 1);
        return new PuzzleResult(computer.RegisterB, "147654bb6c5385ca3e588af0f2a1b077");
    }
}