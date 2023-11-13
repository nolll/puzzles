using Puzzles.common.Computers.Operation;
using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201821;

public class Aoc201821 : AocPuzzle
{
    public override string Name => "Chronal Conversion";
    public override string Comment => "OpComputer";
    public override bool IsSlow => true; // 134s for part 2

    protected override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(InputFile, 0, true);
        return new PuzzleResult(result, "cbaac5c05e7a649e9d578813a7d96c60");
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new OpComputer();
        var result = computer.RunSpecialForDay21(InputFile, 0, false);
        return new PuzzleResult(result, "ea87eb4b91f7e0c9373c7ce75f369320");
    }
}