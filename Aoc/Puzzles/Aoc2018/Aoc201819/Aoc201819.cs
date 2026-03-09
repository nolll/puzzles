using Pzl.Common;
using Pzl.Tools.Computers.Operation;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201819;

[Name("Go With The Flow")]
public class Aoc201819 : AocPuzzle
{
    [Puzzle("890a7c516b44326128b9127982864c47")]
    public long Part1(string input) => new OpComputer().RunInstructionPointerProgram(input, 0, true, false);

    [Puzzle("6d3b9449a0d40e62ed9c6b32e16d95e9")]
    public long Part2(string input) => new OpComputer().RunInstructionPointerProgram(input, 1, true, false);
}