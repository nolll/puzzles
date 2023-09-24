using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202205;

public class Year2022Day05 : AocPuzzle
{
    public override string Name => "Supply Stacks";

    protected override PuzzleResult RunPart1()
    {
        var crane = new CargoCrane(InputFile);
        crane.Run1();
        return new PuzzleResult(crane.Message, "RTGWZTHLD");
    }

    protected override PuzzleResult RunPart2()
    {
        var crane = new CargoCrane(InputFile);
        crane.Run2();
        return new PuzzleResult(crane.Message, "STHGRZZFR");
    }
}