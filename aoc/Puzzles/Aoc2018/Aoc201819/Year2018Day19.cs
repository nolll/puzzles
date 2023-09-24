using Common.Computers.Operation;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Aoc201819;

public class Year2018Day19 : AocPuzzle
{
    public override string Name => "Go With The Flow";

    protected override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var value1 = computer.RunInstructionPointerProgram(InputFile, 0, true, false);
        return new PuzzleResult(value1, 1872);
    }

    protected override PuzzleResult RunPart2()
    {
        var computer2 = new OpComputer();
        var value2 = computer2.RunInstructionPointerProgram(InputFile, 1, true, false);
        return new PuzzleResult(value2, 18_992_592);
    }
}