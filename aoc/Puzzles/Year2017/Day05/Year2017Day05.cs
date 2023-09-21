using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day05;

public class Year2017Day05 : AocPuzzle
{
    public override string Title => "A Maze of Twisty Trampolines, All Alike";

    public override PuzzleResult RunPart1()
    {
        var jumper1 = new InstructionJumper(FileInput);
        jumper1.Start1();
        return new PuzzleResult(jumper1.StepCount, 387_096);
    }

    public override PuzzleResult RunPart2()
    {
        var jumper2 = new InstructionJumper(FileInput);
        jumper2.Start2();
        return new PuzzleResult(jumper2.StepCount, 28_040_648);
    }
}