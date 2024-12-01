using Pzl.Common;
using Pzl.Tools.Computers.Operation;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201819;

[Name("Go With The Flow")]
public class Aoc201819 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var computer = new OpComputer();
        var value1 = computer.RunInstructionPointerProgram(input, 0, true, false);
        return new PuzzleResult(value1, "890a7c516b44326128b9127982864c47");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var computer2 = new OpComputer();
        var value2 = computer2.RunInstructionPointerProgram(input, 1, true, false);
        return new PuzzleResult(value2, "6d3b9449a0d40e62ed9c6b32e16d95e9");
    }
}