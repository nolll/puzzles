using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201705;

[Name("A Maze of Twisty Trampolines, All Alike")]
public class Aoc201705 : AocPuzzle
{
    [Puzzle("3893f5208a5bb1ed3716ffb10c7074d1")]
    public int Part1(string input)
    {
        var jumper1 = new InstructionJumper(input);
        jumper1.Start1();
        return jumper1.StepCount;
    }

    [Puzzle("e9b390d2f610956da9f592bc52c789cc")]
    public int Part2(string input)
    {
        var jumper2 = new InstructionJumper(input);
        jumper2.Start2();
        return jumper2.StepCount;
    }
}