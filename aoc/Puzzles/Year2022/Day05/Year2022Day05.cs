using Aoc.Platform;

namespace Aoc.Puzzles.Year2022.Day05;

public class Year2022Day05 : Puzzle
{
    public override string Title => "Supply Stacks";

    public override PuzzleResult RunPart1()
    {
        var crane = new CargoCrane(FileInput);
        crane.Run1();
        return new PuzzleResult(crane.Message, "RTGWZTHLD");
    }

    public override PuzzleResult RunPart2()
    {
        var crane = new CargoCrane(FileInput);
        crane.Run2();
        return new PuzzleResult(crane.Message, "STHGRZZFR");
    }
}