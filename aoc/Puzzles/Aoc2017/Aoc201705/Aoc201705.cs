using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201705;

public class Aoc201705 : AocPuzzle
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