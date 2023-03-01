using Core.Common.Computers.Operation;
using Core.Platform;

namespace Core.Puzzles.Year2018.Day21;

public class Year2018Day21 : Puzzle
{
    public override string Title => "Chronal Conversion";
    public override string Comment => "OpComputer";
    public override bool IsSlow => true; // 143s for part 2

    public override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(FileInput, 0, true);
        return new PuzzleResult(result, 103_548);
    }

    public override PuzzleResult RunPart2()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(FileInput, 0, false);
        return new PuzzleResult(result, 14_256_686);
    }
}