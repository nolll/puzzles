using Aoc.Common.Computers.Operation;
using Aoc.Platform;

namespace Aoc.Puzzles.Year2018.Day19;

public class Year2018Day19 : Puzzle
{
    public override string Title => "Go With The Flow";

    public override PuzzleResult RunPart1()
    {
        var computer = new OpComputer();
        var value1 = computer.RunInstructionPointerProgram(FileInput, 0, true, false);
        return new PuzzleResult(value1, 1872);
    }

    public override PuzzleResult RunPart2()
    {
        var computer2 = new OpComputer();
        var value2 = computer2.RunInstructionPointerProgram(FileInput, 1, true, false);
        return new PuzzleResult(value2, 18_992_592);
    }
}