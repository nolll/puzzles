using Common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day05;

public class Year2017Day05 : AocPuzzle
{
    public override string Name => "A Maze of Twisty Trampolines, All Alike";

    protected override PuzzleResult RunPart1()
    {
        var jumper1 = new InstructionJumper(InputFile);
        jumper1.Start1();
        return new PuzzleResult(jumper1.StepCount, 387_096);
    }

    protected override PuzzleResult RunPart2()
    {
        var jumper2 = new InstructionJumper(InputFile);
        jumper2.Start2();
        return new PuzzleResult(jumper2.StepCount, 28_040_648);
    }
}