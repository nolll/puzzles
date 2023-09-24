using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Day22;

public class Year2021Day22 : AocPuzzle
{
    public override string Name => "Reactor Reboot";

    protected override PuzzleResult RunPart1()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(InputFile, 50);

        return new PuzzleResult(result, 588200);
    }

    protected override PuzzleResult RunPart2()
    {
        var reactor = new SubmarineReactor();
        var result = reactor.Reboot2(InputFile);

        return new PuzzleResult(result, 1207167990362099);
    }
}