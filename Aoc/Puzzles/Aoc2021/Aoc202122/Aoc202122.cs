using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202122;

[Name("Reactor Reboot")]
public class Aoc202122 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(input, 50);

        return new PuzzleResult(result, "f49f5f28c7496f86abfeaed9d077e669");
    }

    public PuzzleResult RunPart2(string input)
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(input);

        return new PuzzleResult(result, "1b4e931c995f2d8296dc20828a66283b");
    }
}