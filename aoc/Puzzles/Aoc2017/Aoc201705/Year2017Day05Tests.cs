using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201705;

public class Year2017Day05Tests
{
    [Test]
    public void Part1_StepsUntilExit()
    {
        const string input = """
0
3
0
1
-3
""";

        var jumper = new InstructionJumper(input);
        jumper.Start1();

        Assert.That(jumper.StepCount, Is.EqualTo(5));
    }

    [Test]
    public void Part2_StepsUntilExit()
    {
        const string input = """
0
3
0
1
-3
""";

        var jumper = new InstructionJumper(input);
        jumper.Start2();

        Assert.That(jumper.StepCount, Is.EqualTo(10));
    }
}