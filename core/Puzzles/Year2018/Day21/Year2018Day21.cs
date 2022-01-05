using App.Common.Computers.Operation;
using App.Platform;

namespace App.Puzzles.Year2018.Day21;

public class Year2018Day21 : Puzzle
{
    public override string Comment => "OpComputer";
    public override bool IsSlow => true;

    public override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(FileInput, 0);
        return new PuzzleResult(result.first, 103_548);
    }

    public override PuzzleResult RunPart2()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(FileInput, 0);
        return new PuzzleResult(result.last, 14_256_686);
    }
}