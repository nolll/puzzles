using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202122;

public class Aoc202122 : AocPuzzle
{
    public override string Name => "Reactor Reboot";

    protected override PuzzleResult RunPart1()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(InputFile, 50);

        return new PuzzleResult(result, "f49f5f28c7496f86abfeaed9d077e669");
    }

    protected override PuzzleResult RunPart2()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(InputFile);

        return new PuzzleResult(result, "1b4e931c995f2d8296dc20828a66283b");
    }
}