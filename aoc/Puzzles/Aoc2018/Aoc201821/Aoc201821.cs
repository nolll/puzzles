using Common.Computers.Operation;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201821;

public class Aoc201821 : AocPuzzle
{
    public override string Name => "Chronal Conversion";
    public override string Comment => "OpComputer";
    public override bool IsSlow => true; // 143s for part 2

    protected override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(InputFile, 0, true);
        return new PuzzleResult(result, 103_548);
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(InputFile, 0, false);
        return new PuzzleResult(result, 14_256_686);
    }
}