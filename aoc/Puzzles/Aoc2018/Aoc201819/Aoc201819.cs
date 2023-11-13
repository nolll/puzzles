using Puzzles.common.Computers.Operation;
using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201819;

public class Aoc201819 : AocPuzzle
{
    public override string Name => "Go With The Flow";

    protected override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var value1 = computer.RunInstructionPointerProgram(InputFile, 0, true, false);
        return new PuzzleResult(value1, "890a7c516b44326128b9127982864c47");
    }

    protected override PuzzleResult RunPart2()
    {
        var computer2 = new OpComputer();
        var value2 = computer2.RunInstructionPointerProgram(InputFile, 1, true, false);
        return new PuzzleResult(value2, "6d3b9449a0d40e62ed9c6b32e16d95e9");
    }
}