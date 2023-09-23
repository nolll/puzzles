using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day23;

public class Year2015Day23 : AocPuzzle
{
    public override string Name => "Opening the Turing Lock";

    protected override PuzzleResult RunPart1()
    {
        var computer1 = new ChristmasComputer();
        computer1.Run(InputFile);
        return new PuzzleResult(computer1.RegisterB, 307);
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new ChristmasComputer();
        computer.Run(InputFile, 1);
        return new PuzzleResult(computer.RegisterB, 160);
    }
}