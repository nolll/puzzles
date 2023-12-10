using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201623;

[IsSlow] // 196s for part 2
[Name("Safe Cracking")]
[Comment("Factorial of 12")]
public class Aoc201623 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var computer = new SafeCrackingComputerPart1(InputFile, 7, 0);
        return new PuzzleResult(computer.ValueA, "11e66781d74c9188561ba3937d053d99");
    }

    protected override PuzzleResult RunPart2()
    {
        // By inspecting output from the computer I realized that it is calculating the factorial of 12
        var computer = new SafeCrackingComputerPart2(InputFile, 12, 0);
        return new PuzzleResult(computer.ValueA, "eb0c83e21e8bd77e7f0b5686e8f1c31a");
    }
}