using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201705;

[Name("A Maze of Twisty Trampolines, All Alike")]
public class Aoc201705 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var jumper1 = new InstructionJumper(input);
        jumper1.Start1();
        return new PuzzleResult(jumper1.StepCount, "3893f5208a5bb1ed3716ffb10c7074d1");
    }

    public PuzzleResult RunPart2(string input)
    {
        var jumper2 = new InstructionJumper(input);
        jumper2.Start2();
        return new PuzzleResult(jumper2.StepCount, "e9b390d2f610956da9f592bc52c789cc");
    }
}