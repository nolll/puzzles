using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day23;

public class Year2016Day23 : AocPuzzle
{
    public override string Name => "Safe Cracking";

    public override string Comment => "Factorial of 12";
    public override bool IsSlow => true; // 196s for part 2

    public override PuzzleResult RunPart1()
    {
        var computer = new SafeCrackingComputerPart1(FileInput, 7, 0);
        return new PuzzleResult(computer.ValueA, 12_748);
    }

    public override PuzzleResult RunPart2()
    {
        // By inspecting output from the computer I realized that it is calculating the factorial of 12
        var computer = new SafeCrackingComputerPart2(FileInput, 12, 0);
        return new PuzzleResult(computer.ValueA, 479_009_308);
    }
}